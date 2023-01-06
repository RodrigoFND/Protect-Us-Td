using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitStateManagerData
{
    public UnitExternalReference ExternalReference;
    public BasicStatus BasicStatus;
    public Animator Animator;
    public List<SOSkills> ClassSkill = new List<SOSkills>();
    //public List<SOSkills> ActiveSkillsReadyToBeUse = new List<SOSkills>();
    public SOSkills SkillInUseByAnimator;
    public List<UnitExternalReference> EnemiesAround = new List<UnitExternalReference>();
    public UnitExternalReference EnemyTargetLocked;
    public bool _isInAutomaticControl;

}

public class UnitStateManager : MonoBehaviour
{
    public UnityAction<BasicStatus> StatusChangedState;
    public UnityAction<Animator> AnimatorChangedState;
    public UnityAction<List<SOSkills>> ClassSkillChangedState;
    //public UnityAction<List<SOSkills>> ActiveSkillsReadyToBeUseState;
    public UnityAction<SOSkills> SkillInUseByAnimatorState;
    public UnityAction<UnitExternalReference> ExternalReferenceChangeState;
    public UnityAction<List<UnitExternalReference>> EnemiesAroundState;
    public UnityAction<UnitExternalReference> EnemyTargetLockedState;
    public UnityAction<bool> UnitControlChangedState;
 
  
    public UnitStateManagerData StateData { get; private set; } = new UnitStateManagerData();

    public void ExternalReferenceChangeAction(UnitExternalReference externalReference)
    {
        StateData.ExternalReference = externalReference;
        ExternalReferenceChangeState?.Invoke(externalReference);
    }

    public void StatusChangedAction(BasicStatus basicStatus)
    {
        StateData.BasicStatus = basicStatus;
        StatusChangedState?.Invoke(basicStatus);
    }
    public void AnimatorChangedAction(Animator animator)
    {
        StateData.Animator = animator;
        AnimatorChangedState?.Invoke(animator);
    }

    public void ClassSkillChangedAction(List<SOSkills> internalSkills)
    {
        StateData.ClassSkill = internalSkills;
        ClassSkillChangedState?.Invoke(internalSkills);
    }

    //public void ActiveSkillsReadyToBeUseAction(List<SOSkills> activeSkills)
    //{
    //    StateData.ActiveSkillsReadyToBeUse = activeSkills;
    //    ActiveSkillsReadyToBeUseState?.Invoke(activeSkills);
    //}

    public void SkillInUseByAnimatorAction(SOSkills skillInUse)
    {
        StateData.SkillInUseByAnimator = skillInUse;
        SkillInUseByAnimatorState?.Invoke(skillInUse);
    }

    public void EnemiesAroundAction(List<UnitExternalReference> enemysAround)
    {
        StateData.EnemiesAround = enemysAround;
        EnemiesAroundState?.Invoke(enemysAround);
    }

    public void EnemyTargetLockedAction(UnitExternalReference enemy)
    {
        StateData.EnemyTargetLocked = enemy;
        EnemyTargetLockedState?.Invoke(enemy);
    }

    public void UnitControlStateChangedAction(bool isInAutomaticControl)
    {
        StateData._isInAutomaticControl = isInAutomaticControl;
        UnitControlChangedState?.Invoke(isInAutomaticControl);
    }



}
