using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    [SerializeField]
    protected List<SOSkills> _internalDataSkills = new List<SOSkills>();
    [SerializeField]
    protected List<SOBuff> _buffsReceived = new List<SOBuff>();


    private void Start()
    {
        _buffsReceived = _buffsReceived.Select(s => Instantiate(s)).ToList();
    }

    public void ApplyNewBuff(SOSkills externaSkill)
    {
        SOBuff buff = externaSkill as SOBuff;
        if (buff == null) return;
        var skillAlreadyIn = _buffsReceived.FirstOrDefault(s => s.ID == buff.ID);
        if (skillAlreadyIn) skillAlreadyIn.ResetSkillCountDownTimeElapsed();
        else {
            _buffsReceived.Add(buff);
            buff.InitializeSkillHitEffect(null);
        } 
    }

    public void ApplySkill(SOSkills externaSkill)
    {
        ApplyNewBuff(externaSkill as SOBuff);
    }

    protected virtual void FixedUpdate()
    {
        HandleInternalSkill();
        HandleBuffReceivedSkills();
    }

    protected void HandleInternalSkill()
    {
        _internalDataSkills.ForEach(skill =>
        {
            if (skill.SkillCountDownTimeElapsed > 0) skill.SkillCountDownTimeElapsed -= Time.deltaTime;
        });
    }

    private void HandleBuffReceivedSkills()
    {
        _buffsReceived.ForEach(skill =>
        {
            if (skill && skill.ApplyEffectTimeElapsed > 0) skill.ApplyEffectTimeElapsed -= Time.deltaTime;
            if (skill && skill.ApplyEffectTimeElapsed <= 0)
            {
                skill.ApplyEffectOverTime(null);
                skill.ResetApplyEffectTimeElapsed();
            }
            if (skill.SkillCountDownTimeElapsed > 0) skill.SkillCountDownTimeElapsed -= Time.deltaTime;
            if (!skill.IsToogle && skill.SkillCountDownTimeElapsed <= 0) Destroy(skill);
            if (skill.IsToogle && !skill.IsToogleActive) Destroy(skill);
        });
        _buffsReceived = _buffsReceived.Where(s => s).ToList();
    }

}
