using UnityEngine;

[CreateAssetMenu(fileName ="BallCannon",menuName = "Scriptable Objects / Skills / TowerSkills / CannonBall")]
public class SoSkillCannonBall : SOSkills
{
    public override void useSkill(UseSkillAttributes useSkillAttributes)
    {
        
        try
        {
            Debug.Log("Tried");
            if (!useSkillRequeriment()) return;
            if (useSkillAttributes == null) return;
            Instantiate(_startHabilityParticle, useSkillAttributes.StartPoint.transform.position, Quaternion.identity);
            _startHabilityParticle.Play();
            Vector3 targetPoint = useSkillAttributes.TargetPoint.transform.position;
            Instantiate(_hitParticle, targetPoint, Quaternion.identity);
            DamageBehavior damageBehavior = useSkillAttributes.DamageBehavior;
            int damage = useSkillAttributes.AmountDamage + _amount; 
            damageBehavior.ApplyDamage(damage);
            

        } catch
        {
            Debug.Log("Failed to use Skill");
        }
       
    }

    public override bool useSkillRequeriment()
    {
        return SkillCountDownTimeElapsed <= 0;
    }
}
