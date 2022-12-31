using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Targetter : MonoBehaviour
{
    protected float _range;
    [SerializeField]
    protected LayerMask _targetLayers;
    protected List<DamageBehavior> _allTargetsInRange = new List<DamageBehavior>();
    protected DamageBehavior _closestTargetInRange;

    public virtual void Update()
    {
       SearchTargetsAround(_targetLayers);
       SearchClosestTarget();
    }

    //public DamageBehavior GetClosestTargetInRange()
    //{
    //    return _closestTargetInRange;
    //}

    //public List<DamageBehavior> GetAllTargetInRange()
    //{
    //    return _allTargetsInRange;
    //}
    protected bool CheckForDamagableObjects(Collider collider)
    {
        if (collider == null || !collider.TryGetComponent<DamageBehavior>(out var hasDamageBehavior))
        {
            return false;
        }
        return true;
    }

    protected void SearchTargetsAround(LayerMask layerMask)
    {
        var _allTargets = Physics.OverlapSphere(transform.position, _range, layerMask);
        _allTargetsInRange = _allTargets.Where(targets => CheckForDamagableObjects(targets))
            .Select(targets => targets.GetComponent<DamageBehavior>()).
            ToList();
    }

    protected void LockFirstTargetSearched()
    {
        bool isPreviousTargetInRange = _allTargetsInRange.Any(target => target == _closestTargetInRange);
        if (!isPreviousTargetInRange)
        {
            _closestTargetInRange = _allTargetsInRange.Where(enemy => (transform.position - enemy.transform.position).sqrMagnitude > 0).First();
            return;
        }
    }

    protected void SearchClosestTarget()
    {
        if (_allTargetsInRange.Count <= 0)
        {
            _closestTargetInRange = null;
            return;
        }
        if (_closestTargetInRange == null)
        {
            _closestTargetInRange = _allTargetsInRange.Where(enemy => (transform.position - enemy.transform.position).sqrMagnitude > 0).First();
            return;
        }
        LockFirstTargetSearched();
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }


}
