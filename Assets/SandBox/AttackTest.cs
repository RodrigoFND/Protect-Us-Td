using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour
{
    [SerializeField]
    private UnitStateManager unitState;
    private UseSkillRequirements useSkillRequirements;
    [SerializeField]
    private List<SOSkills> _classSkills = new List<SOSkills>();
    [SerializeField]
    private SOSkills skillInUse;

    private void OnEnable()
    {
        unitState.ClassSkillChangedState += setClassSkills;
        unitState.ExternalReferenceChangeState += setRequirements;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            skillInUse = _classSkills[0];
            skillInUse.StartUseSkill(useSkillRequirements);
        }
        if(skillInUse && skillInUse.EndCastSkillTimerElapse <= 0 && skillInUse.SkillInUse)
        {
            skillInUse.EndUseSkill(useSkillRequirements);
        }


    }

    private void setClassSkills(List<SOSkills> skills)
    {
        _classSkills = skills;

    }

    private void setRequirements(UnitExternalReference externalref)
    {
 
        useSkillRequirements = externalref.UseSkillRequirements;
    }



    public void Attack ()
    {

    }
}
