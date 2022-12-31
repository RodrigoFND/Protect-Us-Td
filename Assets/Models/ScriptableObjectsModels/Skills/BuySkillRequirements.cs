using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class BuySkillRequirements
{
    
    public int PointsCostToBuy;
    public List<SOSkills> skillsRequired = new List<SOSkills>();


    public bool CheckRequerimentsMatch(BuySkillRequirements requeriments)
    {
        if (!CheckPointsValid(requeriments.PointsCostToBuy)) return false;
        if (!CheckSkillsValid(requeriments.skillsRequired)) return false;
        return true;

    }

    public bool CheckPointsValid(int points) { return points >= PointsCostToBuy; }
    public bool CheckSkillsValid(List<SOSkills> skillsReceived)
    {
        bool skillsValid = true;
        skillsRequired.ForEach(skill =>
        {
            var skillNotValid = skillsReceived.FirstOrDefault(s => s.ID == skill.ID);
            if (skillNotValid == null)
            {
                skillsValid = false;
                return;
            }
            if (!skillNotValid.IsBought)
            {
                skillsValid = false;
                return;
            }

        });
        return skillsValid;
    }

  
    
    
}
