using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField]
    protected UnitStateManager _unitStateManager;
    protected List<SOSkills> _internalClassSkills = new List<SOSkills>();
    protected List<SOSkills> _externalSkillsReceived = new List<SOSkills>();

    private void OnEnable()
    {
        _unitStateManager.ClassSkillChangedState += (skills) => _internalClassSkills = skills;
    }

    private void OnDisable()
    {
        _unitStateManager.ClassSkillChangedState -= (skills) => _internalClassSkills = skills;
    }

    private void Start()
    {
        _externalSkillsReceived = _externalSkillsReceived.Select(s => Instantiate(s)).ToList();
    }

    public void ApplySkill(SOSkills externaSkill)
    {
        if (externaSkill == null) return;
        var skillAlreadyIn = _externalSkillsReceived.FirstOrDefault(s => s.ID == externaSkill.ID);
        if (skillAlreadyIn) skillAlreadyIn.ResetSkillCountDownTimeElapsed();
        else
        {
            _externalSkillsReceived.Add(externaSkill);
            externaSkill.InitializeSkillHitEffect(null);
        }
    }

    protected virtual void FixedUpdate()
    {
        HandleInternalSkill();
        HandleBuffReceivedSkills();
    }

    protected void HandleInternalSkill()
    {
        _internalClassSkills.ForEach(skill =>
        {
            if (skill.SkillCountDownTimeElapsed > 0) skill.SkillCountDownTimeElapsed -= Time.deltaTime;
            if (skill.SkillInUse && skill.EndCastSkillTimerElapse > 0) skill.EndCastSkillTimerElapse -= Time.deltaTime; // Remover apos teste
            if (!skill.SkillInUse) skill.ResetSkillCastingTimeElapsed();
        });
        //SendClassActiveSkillsReadyToUse();
    }

    private void HandleBuffReceivedSkills()
    {
        _externalSkillsReceived.ForEach(skill =>
        {
            if (skill && skill.ApplyEffectTimeElapsed > 0) skill.ApplyEffectTimeElapsed -= Time.deltaTime;
            if (skill && skill.ApplyEffectTimeElapsed <= 0)
            {
                skill.ApplyEffectOverTime(null);
                skill.ResetSkillEffectTimeElapsed();
            }
            if (skill.SkillCountDownTimeElapsed > 0) skill.SkillCountDownTimeElapsed -= Time.deltaTime;
            if (!skill.IsToogle && skill.SkillCountDownTimeElapsed <= 0) Destroy(skill);
            if (skill.IsToogle && !skill.IsToogleActive) Destroy(skill);
        });
        _externalSkillsReceived = _externalSkillsReceived.Where(s => s).ToList(); // Remove empty rows
    }

    //private void SendClassActiveSkillsReadyToUse()
    //{
    //    List<SOSkills> skillsReadyOnState = _unitStateManager.StateData.ActiveSkillsReadyToBeUse.ToList();
    //  var activeSkillsReadyToBeUsed = _internalClassSkills.Where(s => s.ClassificationType == ESkillClassificationType.Active).ToList();
    //    if (skillsReadyOnState == null || skillsReadyOnState.Count != activeSkillsReadyToBeUsed.Count)
    //    {
    //        _unitStateManager.ActiveSkillsReadyToBeUseAction(activeSkillsReadyToBeUsed);
    //        return;
    //    }
    //    IEnumerable<SOSkills> except = activeSkillsReadyToBeUsed.Except(skillsReadyOnState);
    //    if (except.Count() > 0)
    //    {
    //        _unitStateManager.ActiveSkillsReadyToBeUseAction(activeSkillsReadyToBeUsed);
    //    }
    //}

}
