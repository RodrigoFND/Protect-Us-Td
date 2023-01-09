using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Scriptable Objects / Skills / TowerSkills / Projectile")]
public class SOProjectileSkill : SOSkills
{
    [Header("Projectile attributes")]
    [SerializeField]
    public float _projectileSpeed;
    [SerializeField]
    public GameObject _projectilePreFab;
    public GameObject projectileInstantiated;
    [SerializeField]
    private UseSkillRequirements _useSkillRequerimentsProjectileReference;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    Projectile _projectile;

    public GameObject Target => _target;
    public Projectile Projectile => _projectile;
    public float Speed => _projectileSpeed;
    public UseSkillRequirements UseSkillRequerimentsProjectileReference => _useSkillRequerimentsProjectileReference;




    public override void PlaySkillAnimation(UseSkillRequirements useSkillRequirements, out bool playAnimationFailed)
    {
        base.PlaySkillAnimation(useSkillRequirements, out bool animationFailed);
        playAnimationFailed = animationFailed;
        try {
            _target = useSkillRequirements.Targatable.LockedTarget.UseSkillRequirements.Hittable.HittableComponent;
        } catch
        {
            playAnimationFailed = false;
        }
      
    }

    public override void EndUseSkill(UseSkillRequirements useSkillRequirements)
    {
        GameObject instantiatePoint = useSkillRequirements.Attackable.AttackPosition;
        projectileInstantiated = Instantiate(_projectilePreFab,instantiatePoint.transform.position,Quaternion.identity);
        _projectile = projectileInstantiated.GetComponent<Projectile>();
        _projectile.SetSkill(this);
    }


    public override void InitializeSkillHitEffect(UseSkillRequirements useSkillRequirements)
    {
        if(_projectile != null)
        {
            Debug.Log(_projectile.gameObject.transform.position);
            Instantiate(EndSkillParticle, _projectile.gameObject.transform.position, Quaternion.identity);

        }


    }

    public override void StartUseSkill(UseSkillRequirements useSkillRequirements)
    {
        
    }

    public override void EndSkillEffect(UseSkillRequirements useSkillRequirements)
    {
      
    }


    public override bool UseSkillRequeriment(UseSkillRequirements useSkillRequirements)
    {
        return true;

    }
    public override void ApplyEffectOverTime(UseSkillRequirements useSkillRequirements)
    {

    }

    public override void CancelStartSkill()
    {

    }

   



  


}
