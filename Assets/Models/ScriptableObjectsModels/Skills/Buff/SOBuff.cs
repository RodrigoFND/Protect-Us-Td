using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Buff",menuName = "Scriptable Objects/ Skills/ Buff Skills")]
public  class SOBuff : SOSkills
{
    [Header("Buff Effect Timer")]
    [SerializeField]
    protected float _applyEffectTimer;
    [SerializeField]
    protected bool _isToogle;
    protected bool _isToogleActive;

    public float ApplyEffectTimeElapsed;
    public float ApplyEffectTimer => _applyEffectTimer;
    public bool IsToogle => _isToogle;
    public bool IsToogleActive => _isToogleActive;

    public virtual void InitializeSkillHitEffect(UseSkillAttributes useSkillRequirements)
    {

    }

    public virtual void ApplyEffectOverTime(UseSkillAttributes useSkillRequirements)
    {

    }

    public override bool useSkillRequeriment()
    {
        throw new System.NotImplementedException();
    }

    public override void useSkill(UseSkillAttributes useSkillRequirements)
    {
        throw new NotImplementedException();
    }

    public void ResetApplyEffectTimeElapsed()
    {
        ApplyEffectTimeElapsed = _applyEffectTimer;
    }
}
