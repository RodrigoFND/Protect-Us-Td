using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerTargetter : Targetter
{
    [SerializeField]
    private TowerStateManager _towerStateManager;

    private void OnEnable()
    {
        _towerStateManager.TowerStatusChangedState += ChangeRange;
    }

    private void OnDisable()
    {
        _towerStateManager.TowerStatusChangedState -= ChangeRange;
    }

    public override void Update()
    {
        SearchTargetsAround(_targetLayers);
        SearchClosestTarget();
        SendActionEnemiesAround();
        SendActionSingleTargetLocked();
    }

    public void SendActionEnemiesAround()
    {
        List<DamageBehavior> enemiesInState = _towerStateManager.TowerStateDate._enemiesAround;
        if (enemiesInState == null || enemiesInState.Count != _allTargetsInRange.Count)
        {
            _towerStateManager.EnemiesAroundAction(_allTargetsInRange);
            return;
        }
        IEnumerable<DamageBehavior> except = _allTargetsInRange.Except(enemiesInState);
        if(except.Count() > 0)
        {
            _towerStateManager.EnemiesAroundAction(_allTargetsInRange);
        }  
    }

    public void SendActionSingleTargetLocked()
    {
        var stateEnemieLocked = _towerStateManager.TowerStateDate._enemyTargetLocked;
        if (stateEnemieLocked != _closestTargetInRange)
        {
            _towerStateManager.EnemyTargetLockedAction(_closestTargetInRange);
        }
    }

    private void ChangeRange(TowerStatus status)
    {
        _range = status.Range;
    }

}
