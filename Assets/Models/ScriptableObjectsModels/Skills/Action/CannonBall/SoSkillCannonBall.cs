using JetBrains.Annotations;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName ="BallCannon",menuName = "Scriptable Objects / Skills / TowerSkills / CannonBall")]
public class SoSkillCannonBall : SOSkills
{
    private ParticleSystem _startParticleInstantiated;
    public override void PlaySkillAnimation(UseSkillRequirements useSkillRequirements, out bool playAnimationFailed)
    {
        if (!UseSkillRequeriment(useSkillRequirements)) {
            playAnimationFailed = true;
            return;
        }
        Animator animator = useSkillRequirements.Animation.GetAnimator();
        AnimationClip animationClip = Generics.GetAnimationClip(animator, _startSkillAnimationName);
        if (animationClip == null)
        {
            playAnimationFailed = true;
            return;
        }
        int playerAtkSpeed = useSkillRequirements.BasicStatus.GetAtkSpeed();
        float animationSpeed = Generics.CalculateAnimationSpeed(playerAtkSpeed, _skillAttackSpeed);
        animator.SetFloat("LayerOneAnimationSpeed", animationSpeed);
        animator.Play(_startSkillAnimationName);
        _isSkillPlayingStartAnimation = true;
        playAnimationFailed = false;
    }
    public override void StartUseSkill(UseSkillRequirements useSkillRequirements)
    {
        _skillInUse = true;
        if (!UseSkillRequeriment(useSkillRequirements)) return;
        if (useSkillRequirements == null) return;
        _startParticleInstantiated = Instantiate(_startSkillParticle, useSkillRequirements.Hittable.HittableComponent.transform.position, Quaternion.identity);
        _startSkillParticle.Play();
    }
    public override void CancelStartSkill()
    {
        _isSkillPlayingStartAnimation = false;
        if(_startParticleInstantiated) 
        {
            var main = _startParticleInstantiated.main;
            main.loop = false;
        }
       
    }

    public override void EndUseSkill(UseSkillRequirements useSkillRequirements)
    {

        CancelStartSkill();
        if(useSkillRequirements.Targatable.LockedTarget == null) return; 
        if (!UseSkillRequeriment(useSkillRequirements)) return;
        if (useSkillRequirements == null) return;
        Vector3 targetPoint = useSkillRequirements.Targatable.LockedTarget.transform.position;
        Instantiate(_endSkillParticle, targetPoint, Quaternion.identity);
        int damage = useSkillRequirements.Amount + _amount;
        useSkillRequirements.Hittable.HitComponent(damage);
    }
    //public override void useSkill(UseSkillRequirements useSkillAttributes)
    //{
    //    try
    //    {
    //        if (!useSkillRequeriment(useSkillAttributes)) return;
    //        if (useSkillAttributes == null) return;
    //        Instantiate(_startHabilityParticle, useSkillAttributes.Hittable.HittableComponent.transform.position, Quaternion.identity);
    //        _startHabilityParticle.Play();
    //        Vector3 targetPoint = useSkillAttributes.Targatable.LockedTarget.transform.position;
    //        Instantiate(_hitParticle, targetPoint, Quaternion.identity);
    //        int damage = useSkillAttributes.Amount + _amount;
    //        useSkillAttributes.Hittable.HitComponent(damage);
    //    }
    //    catch
    //    {
    //        Debug.Log("Failed to use Skill");
    //    }
    //}

    public override bool UseSkillRequeriment(UseSkillRequirements useSkillAttributes)
    {
        return SkillCountDownTimeElapsed <= 0;
    }
    public override void ApplyEffectOverTime(UseSkillRequirements useSkillRequirements)
    {
    
    }

    public override void EndSkillEffect(UseSkillRequirements useSkillRequirements)
    {

    }

    public override void InitializeSkillHitEffect(UseSkillRequirements useSkillRequirements)
    {
      
    }
}
