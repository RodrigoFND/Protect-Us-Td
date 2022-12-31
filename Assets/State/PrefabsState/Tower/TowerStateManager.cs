using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TowerStateManagerData
{
    public TowerStatus TowerStatus;
    public List<SOSkills> TowerSkills;
    public List<DamageBehavior> _enemiesAround;
    public DamageBehavior _enemyTargetLocked;
}

public class TowerStateManager : MonoBehaviour
{
    public UnityAction<TowerStatus> TowerStatusChangedState;
    public UnityAction<List<SOSkills>> TowerSkillsChangedState;
    public UnityAction<List<DamageBehavior>> EnemiesAroundState;
    public UnityAction<DamageBehavior> EnemyTargetLockedState;
    public UnityAction<int> TowerHittedState;
    public UnityAction TowerBuffsAppliedState;
    public UnityAction TowerDebuffAppliedState;
    public TowerStateManagerData TowerStateDate { get; private set; } = new TowerStateManagerData();

    public void TowerStatusChangedAction(TowerStatus towerStatus)
    {
        TowerStateDate.TowerStatus = towerStatus;
        TowerStatusChangedState?.Invoke(towerStatus);
    }

    public void TowerSkillsChangedAction(List<SOSkills> towerSkills)
    {
        TowerStateDate.TowerSkills = towerSkills;
        TowerSkillsChangedState?.Invoke(towerSkills);
    }

    public void TowerHittedAction(int hitDamage)
    {
        TowerHittedState?.Invoke(hitDamage);
    }

    public void EnemiesAroundAction(List<DamageBehavior> enemysAround)
    {
        TowerStateDate._enemiesAround = enemysAround;
        EnemiesAroundState?.Invoke(enemysAround);
    }

    public void EnemyTargetLockedAction(DamageBehavior enemy)
    {
        TowerStateDate._enemyTargetLocked = enemy;
        EnemyTargetLockedState?.Invoke(enemy);
    }

}
