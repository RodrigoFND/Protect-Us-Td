using JetBrains.Annotations;
using Panda;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TowerStateMachineBehaviorTree : MonoBehaviour
{
    [SerializeField]
    private UnitStateManager _unitStateManager;
    private UnitExternalReference _unitExternalReference;
    [SerializeField]
    private List<SOSkills> _internalClassSkills;
    private ITargatable _targatable;
    private Animator _animator;
    private bool tempVariableCanAttack = true;
    private SOSkills _skillSetByBehaviorTree;
    private SOSkills _skillInUseByAnimator;
    private UnitExternalReference _currentLockedTargetToAttack;

    private void OnEnable()
    {
        _unitStateManager.ExternalReferenceChangeState += SetExternalReference;
        _unitStateManager.ClassSkillChangedState += SetClassSkills;
        _unitStateManager.AnimatorChangedState += SetAnimator;
        _unitStateManager.SkillInUseByAnimatorState += SetSkillInUseByAnimator;
    }

    private void OnDisable()
    {
        _unitStateManager.ExternalReferenceChangeState -= SetExternalReference;
        _unitStateManager.ClassSkillChangedState -= SetClassSkills;
        _unitStateManager.AnimatorChangedState -= SetAnimator;
        _unitStateManager.SkillInUseByAnimatorState -= SetSkillInUseByAnimator;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) )
        {
            tempVariableCanAttack = true;
            //var skill = _activeSkillsReady[0];
            //_unitStateManager.SkillInUseByAnimatorAction(skill);

            //skill.PlaySkillAnimation(_unitExternalReference.UseSkillRequirements,out string _animationName);
            //string animationName = _animationName;

        }
        if (Input.GetMouseButtonDown(1))
        {
            tempVariableCanAttack = false;
  

        }
        HandleUnfinishedStartedSkill();
    }

    private void SetExternalReference(UnitExternalReference externalReference)
    {
        _unitExternalReference = externalReference;
        _targatable = externalReference.UseSkillRequirements.Targatable;
    }

    private void SetAnimator(Animator animator) => _animator = animator;
    private void SetSkillInUseByAnimator(SOSkills skillInUse) => _skillInUseByAnimator = skillInUse;
    private void SetClassSkills(List<SOSkills> classSkills) => _internalClassSkills = classSkills;

    private void HandleUnfinishedStartedSkill()
    {
        var activeSkillInUse = _unitStateManager.StateData.SkillInUseByAnimator;
        if (activeSkillInUse == null || activeSkillInUse.SkillInUse == false) return;
        if(Generics.AnimationIsPlaying(_animator, activeSkillInUse.StartSkillAnimationName) == false)
        {
            activeSkillInUse.CancelStartSkill();
            //_unitStateManager.SkillInUseByAnimatorAction(null);
        }

    }

    [Task]
    public void IdleAnimation()
    {
        if (!Generics.AnimationIsPlaying(_animator,"Idle"))
        {
            _animator.Play("Idle");
            return;
        }
    }

    [Task]
    public bool CheckCanAttack()
    {
        return tempVariableCanAttack;
    }

    [Task]
    public bool CheckEnemiesAround()
    {
        var enemiesAround = _unitStateManager.StateData.EnemiesAround;
        if(enemiesAround == null || enemiesAround.Count <= 0)
        {
            return false;
        }
        return true;

    }


    [Task]
    public void LockClosestTarget()
    {
        _targatable.LockClosestTarget(true);
        if(_targatable.LockedTarget == null)
        {
            ThisTask.Fail();
            return;
        }
        _currentLockedTargetToAttack = _targatable.LockedTarget;
        ThisTask.Succeed();
    }

    [Task]
    public void FindAndSetActiveSkillReady()
    {
        if(_internalClassSkills == null || _internalClassSkills.Count <=0) ThisTask.Fail();
        var skillRequirements = _unitExternalReference.UseSkillRequirements;
        _skillSetByBehaviorTree = _internalClassSkills.FirstOrDefault(s => s.UseSkillRequeriment(skillRequirements));
        if(_skillSetByBehaviorTree != null)
        {
            ThisTask.Succeed();
            return;
        }
        ThisTask.Fail();
        return;
    }

    [Task]
    public void PlaySkillAttackAnimation()
    {

        _skillSetByBehaviorTree.PlaySkillAnimation(_unitExternalReference.UseSkillRequirements, out bool playAnimationFailed);
        if (playAnimationFailed)
        {
            _unitStateManager.SkillInUseByAnimatorAction(null);
            ThisTask.Fail();
            return;
        }
        if(!playAnimationFailed)
        {
            _unitStateManager.SkillInUseByAnimatorAction(_skillSetByBehaviorTree);
            ThisTask.Succeed();
        }

    }

    [Task]
    public void RotateTowardsTargetLocked()
    {
    

    }

    [Task]
    public void WaitSkillStartToPlay()
    {
     
        if (Generics.AnimationIsPlaying(_animator, _skillInUseByAnimator.StartSkillAnimationName)) {
            ThisTask.Succeed();
            return ;
        }
    }

    [Task]
    public void SkillAnimationHasEnded()
    {
        if (!Generics.AnimationIsPlaying(_animator, _skillInUseByAnimator.StartSkillAnimationName))
        {
            _unitStateManager.SkillInUseByAnimatorAction(null);
            ThisTask.Succeed();
            return;
        }
        ThisTask.Fail();
    }


}
