using UnityEngine;

public class AnimationEvents : MonoBehaviour, IAnimationCannon
{
    [SerializeField]
    private UnitStateManager _unitStateManager;
    private SOSkills _activeSkillToUse;
    private UseSkillRequirements _useSkillRequirements;

    private void OnEnable()
    {
        _unitStateManager.SkillInUseByAnimatorState += SetSkillInUse;
        _unitStateManager.ExternalReferenceChangeState += SetExternalReference;
    }

    private void OnDisable()
    {
        _unitStateManager.SkillInUseByAnimatorState -= SetSkillInUse;
        _unitStateManager.ExternalReferenceChangeState -= SetExternalReference;
    }

    public void EndCannonFireAnimation() => _activeSkillToUse.EndUseSkill(_useSkillRequirements);
    public void StartCannonFireAnimation() => _activeSkillToUse.StartUseSkill(_useSkillRequirements);
    private void SetSkillInUse(SOSkills skill) => _activeSkillToUse = skill;
    private void SetExternalReference(UnitExternalReference unitExternalReference) => _useSkillRequirements = unitExternalReference.UseSkillRequirements;

   

}
