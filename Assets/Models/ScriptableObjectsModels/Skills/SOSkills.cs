using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

public abstract class SOSkills : ScriptableObject
{
    [SerializeField]
    protected int _id;
    [SerializeField]
    protected string _abilityName;
    [SerializeField]
    protected string _abilityDescription;
    [SerializeField]
    protected Sprite _abilitySprite;
    [SerializeField]
    protected float _skillCountDownTimer;
    public float SkillCountDownTimeElapsed;
    [Header("Particle")]
    protected ParticleSystem _startHabilityParticle;
    protected ParticleSystem _hitParticle;
    [SerializeField]
    protected int _amount;
    [Header("Requiments to Buy")]
    [SerializeField]
    protected bool _isBought;
    [SerializeField]
    protected BuySkillRequirements _buySkillsRequirements = new BuySkillRequirements();
    public int ID => _id;
    public string AbilityName => _abilityName;
    public string AbilityDescription => _abilityDescription;
    public Sprite AbilitySprite => _abilitySprite;
    public int Amount => _amount;
    public bool IsBought => _isBought;
   
    public ParticleSystem StartHabilityParticle => _startHabilityParticle;
    public ParticleSystem HitParticle => _hitParticle;


    public virtual void BuySkill(BuySkillRequirements skillRequeriments)
    {
        if(!CheckSkillRequerimentsToBuy(skillRequeriments))
        {
            Debug.Log("Requirements not fullfilled");
            return;
        }
      
        _isBought = true;
    }

    public void ResetSkillCountDownTimeElapsed()
    {
        SkillCountDownTimeElapsed = _skillCountDownTimer;
    }

    public abstract bool useSkillRequeriment();
    public abstract void useSkill(UseSkillAttributes useSkillRequirements);

    protected  bool CheckIsSkillBought()
    {
        if (_isBought)
        {
            Debug.Log("Skill already bought");
            return false;
        }
        return true;
    }

    protected bool CheckSkillRequerimentsToBuy(BuySkillRequirements skillRequeriments )
    {
        if(!_isBought) return false;
        return _buySkillsRequirements.CheckRequerimentsMatch(skillRequeriments);

    }

    //protected  bool CheckisPointSufficientToBuy(int points)
    //{
    //    if (points < _pointCostToBuy)
    //    {
    //        Debug.Log("Not enought points");
    //        return false;
    //    }
    //    return true;
    //}

    //protected bool CheckTowersRequerimentsBought()
    //{
    //    var skillNotBought = SkillsRequired.FirstOrDefault(s => !s.IsBought);
    //    if (SkillsRequired.Count > 0 && skillNotBought)
    //    {
    //        return false;
    //    }

    //    return true;
    //}

    //protected virtual bool CheckAbilityBuyPreConditions(int point)
    //{
    //    if (CheckIsSkillBought()) return false;
    //    if (!CheckisPointSufficientToBuy(point)) return false;
    //    if (!CheckTowersRequerimentsBought()) return false;
    //    return true;
    //}

}
