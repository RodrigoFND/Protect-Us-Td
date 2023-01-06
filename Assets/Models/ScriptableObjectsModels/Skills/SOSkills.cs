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
    protected ESkillClassificationType _classificationType;
    [SerializeField]
    protected int _skillAttackSpeed;
    [SerializeField]
    protected float _skillCountDownTimer;
    public float SkillCountDownTimeElapsed;
    [SerializeField]
    protected bool _isToogle;
    protected bool _isToogleActive;
    [Header("Skill Casting Timer")]
    [SerializeField]
    protected float _endCastSkillTimer; // Remover apos teste
    public float EndCastSkillTimerElapse; // Remover apos teste
    [SerializeField]
    protected bool _skillInUse; // Remover apos teste
    [SerializeField]
    protected int _amount;
    [Header("Requiments to Buy")]
    [SerializeField]
    protected bool _isBought;
    [SerializeField]
    protected BuySkillRequirements _buySkillsRequirements = new BuySkillRequirements();
    [Header("Hit Effect Timer")]
    [SerializeField]
    protected float _applyEffectTimer;
    public float ApplyEffectTimeElapsed;
    [Header("Animation Settings")]
    [SerializeField]
    protected string _startSkillAnimationName;
    protected bool _isSkillPlayingStartAnimation;
    [SerializeField]
    protected ParticleSystem _startSkillParticle;
    [SerializeField]
    protected ParticleSystem _endSkillParticle;


    public float EndCastSkillTimer => _endCastSkillTimer; // Remover apos teste
    public bool SkillInUse => _skillInUse; // Remover apos teste
    public ESkillClassificationType ClassificationType => _classificationType;
  
    public float ApplyEffectTimer => _applyEffectTimer;
    public int ID => _id;
    public string AbilityName => _abilityName;
    public string AbilityDescription => _abilityDescription;
    public Sprite AbilitySprite => _abilitySprite;
    public bool IsToogle => _isToogle;
    public bool IsToogleActive => _isToogleActive;

    public int Amount => _amount;
    public bool IsBought => _isBought;
   
    public ParticleSystem StartSkillParticle => _startSkillParticle;
    public ParticleSystem EndSkillParticle => _endSkillParticle;
    public delegate void MyDelegate(BuySkillRequirements skillRequeriments);
    public bool IsSkillPlayingStartAnimation  =>_isSkillPlayingStartAnimation;
    public string StartSkillAnimationName => _startSkillAnimationName;



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

    public void ResetSkillEffectTimeElapsed()
    {
        ApplyEffectTimeElapsed = _applyEffectTimer;
    }

    public void ResetSkillCastingTimeElapsed()
    {
        EndCastSkillTimerElapse = _endCastSkillTimer;
    }

    public abstract bool UseSkillRequeriment(UseSkillRequirements useSkillRequirements);
    public abstract void PlaySkillAnimation(UseSkillRequirements useSkillRequirements,out bool playAnimationFailed);
    //public abstract void useSkill(UseSkillRequirements useSkillRequirements);
    public abstract void StartUseSkill(UseSkillRequirements useSkillRequirements);
    public abstract void CancelStartSkill();
    public abstract void EndUseSkill(UseSkillRequirements useSkillRequirements);
    public abstract void InitializeSkillHitEffect(UseSkillRequirements useSkillRequirements);
    public abstract void ApplyEffectOverTime(UseSkillRequirements useSkillRequirements);
    public abstract void EndSkillEffect(UseSkillRequirements useSkillRequirements);

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

}
