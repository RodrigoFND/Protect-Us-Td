using UnityEngine;

public class UnitExternalReference : MonoBehaviour
{
    [SerializeField]
    private UnitStateManager _unitStateManager;
    [SerializeField]
    private SkillManager _skillManager;
    [SerializeField]
    private DamageBehavior _damageBehavior;
    [SerializeField]
    private Targetter _targetter;
    [SerializeField]
    private Hittable _hittable;
    [SerializeField]
    private Unit _unit;
    private UseSkillRequirements _useSkillRequirements;
    private IBasicStatus _IbasicStatus;
    private ITargatable _Itargetter;
    private IHealable _Ihealable;
    private IHittable _Ihittable;
    private IAnimation _Ianimation;
    private IControlUnit _IcontrolUnit;
    private IAttackable _Iattackable;

    private void Start()
    {
        _IbasicStatus = _unit;
        _Itargetter = _targetter;
        _Ihealable = _unit;
        _Ihittable = _hittable;
        _Ianimation = _unit;
        _IcontrolUnit = _unit;
        _Iattackable = _unit;
        setSkillRequirements();
    }

    public void setSkillRequirements()
    {
        _useSkillRequirements = new UseSkillRequirements(10, _IbasicStatus, _Itargetter, _Ihittable,_Ihealable, _Ianimation, _IcontrolUnit, _Iattackable);
        _unitStateManager.ExternalReferenceChangeAction(this);
    }

    public UseSkillRequirements UseSkillRequirements => _useSkillRequirements;

    //public UseSkillRequirements SkillRequeriments => _useSkillRequirements;
}
