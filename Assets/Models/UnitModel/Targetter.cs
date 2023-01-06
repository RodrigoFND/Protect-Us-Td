using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Targetter : MonoBehaviour, ITargatable
{

    [SerializeField]
    private UnitStateManager _unitStateManager;
    [SerializeField]
    private LayerMask _componentLayer;
    [SerializeField]
    protected List<UnitExternalReference> _allTargetsInRange = new List<UnitExternalReference>();
    [SerializeField]
    protected UnitExternalReference _closestTargetInRange;
    [SerializeField]
    protected UnitExternalReference _targetLocked;
    protected float _range;
    public LayerMask ComponentLayer => _componentLayer;
    public LayerMask LayerToFocus { get; set; }
    public List<UnitExternalReference> AllTargetInRange => _allTargetsInRange;
    public UnitExternalReference ClosestTarget => _closestTargetInRange;
    public UnitExternalReference LockedTarget => _targetLocked;


    private void OnEnable()
    {
        _unitStateManager.StatusChangedState += ChangeRange;
    }

    private void OnDisable()
    {
        _unitStateManager.StatusChangedState -= ChangeRange;
    }

    public void Start()
    {
        LayerToFocus = _componentLayer;
    }

    public  void Update()
    {
        SearchTargetsAround();
        SearchClosestTarget();
        SendActionEnemiesAround();
        SendActionSingleTargetLocked();
    }


    private void ChangeRange(BasicStatus status)
    {
        _range = status.Range;
    }

    public void SearchTargetsAround()
    {
        var _allTargets = Physics.OverlapSphere(transform.position, _range, LayerToFocus);
        _allTargetsInRange = _allTargets.Where(targets => CheckForExternaReferenceObjects(targets))
            .Select(targets => targets.GetComponent<UnitExternalReference>()).
            ToList();
    }

    public void SearchClosestTarget()
    {
        if (_allTargetsInRange.Count <= 0)
        {
            _closestTargetInRange = null;
            return;
        }
            _closestTargetInRange = _allTargetsInRange.OrderBy(enemy => (transform.position - enemy.transform.position).sqrMagnitude).First();
    }

    public void LockClosestTarget(bool keepLastReference)
    {
        if (_targetLocked == null || !keepLastReference)
        {
            _targetLocked = _closestTargetInRange;
            return;
        }

        bool isTargetPreviouslyLockedStillAvailable = _allTargetsInRange.Any(target => target == _targetLocked);
        if (!isTargetPreviouslyLockedStillAvailable)
        {
            _targetLocked = _closestTargetInRange;
            return;
        }
    }

    protected bool CheckForExternaReferenceObjects(Collider collider)
    {
        if (collider == null || !collider.TryGetComponent<UnitExternalReference>(out var externalReference))
        {
            return false;
        }
        return true;
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    protected void SendActionEnemiesAround()
    {
        List<UnitExternalReference> enemiesInState = _unitStateManager.StateData.EnemiesAround;
        if (enemiesInState == null || enemiesInState.Count != _allTargetsInRange.Count)
        {
            _unitStateManager.EnemiesAroundAction(_allTargetsInRange);
            return;
        }
        IEnumerable<UnitExternalReference> except = _allTargetsInRange.Except(enemiesInState);
        if (except.Count() > 0)
        {
            _unitStateManager.EnemiesAroundAction(_allTargetsInRange);
        }
    }

    protected void SendActionSingleTargetLocked()
    {
        var stateEnemieLocked = _unitStateManager.StateData.EnemyTargetLocked;
        if (stateEnemieLocked != _targetLocked)
        {
            _unitStateManager.EnemyTargetLockedAction(_closestTargetInRange);
        }
    }
}
