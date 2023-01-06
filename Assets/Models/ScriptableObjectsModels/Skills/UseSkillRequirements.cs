using UnityEngine;

public class UseSkillRequirements
{
    protected int _amount;
    protected IBasicStatus _basicStatus;
    protected ITargatable _targetable;
    protected IHittable _hittable;
    protected IHealable _healable;
    protected IAnimation _animation;
    protected IControlUnit _controlUnit;

    public UseSkillRequirements(int amount, IBasicStatus basicStatus, ITargatable targetable, IHittable hittable, IHealable healable, IAnimation animation, IControlUnit controlUnit)
    {
        _amount = amount;
        _basicStatus = basicStatus;
        _targetable = targetable;
        _hittable = hittable;
        _healable = healable;
        _animation = animation;
        _controlUnit = controlUnit;
    }

    public int Amount => _amount;
    public IBasicStatus BasicStatus => _basicStatus;
    public ITargatable Targatable => _targetable;
    public IHittable Hittable => _hittable;
    public IHealable Healable => _healable;
    public IAnimation Animation => _animation;
    public IControlUnit ControlUnit => _controlUnit;

}
