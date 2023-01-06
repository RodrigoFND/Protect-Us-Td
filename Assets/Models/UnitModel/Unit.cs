using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour, IBasicStatus, IHealable, IAnimation, IControlUnit
{
    [SerializeField]
    protected UnitStateManager _unitStateManager;
    [SerializeField]
    protected Animator _animator;
    protected BasicStatus _basicStatus = new BasicStatus();
    protected List<SOSkills> _classSkills = new List<SOSkills>();
    protected bool _isUnitInAutomaticControl;
    public bool CanHealHP { get; set; }
    public int HP => _basicStatus.HP;
    public int MP => _basicStatus.MP;
    public float PhysicalAttack => _basicStatus.PhysicalAttack;
    public float MagicalAttack => _basicStatus.PhysicalAttack;
    public int AttackSpeed => _basicStatus.AttackSpeed;
    public int CriticalChance => _basicStatus.CriticalChance;
    public int CriticalPower => _basicStatus.CriticalPower;
    public int Defense => _basicStatus.Defense;
    public float Range => _basicStatus.Range;
    public bool IsUnitInAutomaticControl;

    public virtual void SetHp(int amount)
    {
        _basicStatus.HP += amount;
        _basicStatus.HP = _basicStatus.HP > 0 ? _basicStatus.HP : 0;
        _unitStateManager.StatusChangedAction(_basicStatus);
    }

    public virtual void HealHP(int amount)
    {
        if (!CanHealHP) return;
        SetHp(amount);
        _unitStateManager.StatusChangedAction(_basicStatus);
    }

    public void SetCanHealHp(bool amount)
    {
        throw new System.NotImplementedException();
    }

    public Animator GetAnimator()
    {
        return _animator;
    }

    public int GetHp()
    {
        return HP;
    }

    public int GetAtkSpeed()
    {
        return AttackSpeed;
    }

    public void ChangeUnitToAutomaticControl()
    {
     
    }

    public void ChangeUnitToManualControl()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeUnitControl(bool isAutomatic)
    {
        IsUnitInAutomaticControl = isAutomatic;
        _unitStateManager.UnitControlStateChangedAction(isAutomatic);
    }


    //private void SetHP(int hpAmout)
    //{
    //    _towerStatus.HP += hpAmout;
    //    _towerStatus.HP = _towerStatus.HP > 0 ? _towerStatus.HP : 0;
    //    _towerStateManager.TowerStatusChangedAction(_towerStatus);
    //}

    //private void SetMP(int mpAmout)
    //{
    //    _towerStatus.MP += mpAmout;
    //    _towerStatus.MP = _towerStatus.MP > 0 ? _towerStatus.MP : 0;
    //    _towerStateManager.TowerStatusChangedAction(_towerStatus);
    //}

    //private void SetPAttack(int pAttack)
    //{
    //    _towerStatus.PhysicalAttack += pAttack;
    //    _towerStatus.PhysicalAttack = _towerStatus.PhysicalAttack > 0 ? _towerStatus.PhysicalAttack : 0;
    //    _towerStateManager.TowerStatusChangedAction(_towerStatus);
    //}

    //public void SetHp(int amount)
    //{
    //    Debug.Log(IBasicStatus.canSetHp);
    //}
}
