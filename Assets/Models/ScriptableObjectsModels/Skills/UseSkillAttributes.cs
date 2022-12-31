using UnityEngine;

public class UseSkillAttributes
{
    protected GameObject _startPoint;
    protected GameObject _targetPoint;
    protected int _amountDamage;
    protected DamageBehavior _damageBehavior;

    public GameObject StartPoint => _startPoint;
    public GameObject TargetPoint => _targetPoint;
    public int AmountDamage => _amountDamage;
    public DamageBehavior DamageBehavior => _damageBehavior;

}
