using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class BuyTowerRequirements
{
    public int PointsCostToBuy;
    public List<SOTowerLevel> towersRequired = new List<SOTowerLevel>();

    public bool CheckRequerimentsMatch(BuyTowerRequirements requeriments)
    {
        if (!CheckPointsValid(requeriments.PointsCostToBuy)) return false;
        if (!CheckTowersValid(requeriments.towersRequired)) return false;
        return true;
    }

    public bool CheckPointsValid(int points) { return points >= PointsCostToBuy; }
    public bool CheckTowersValid(List<SOTowerLevel> towersReceived)
    {
        bool towersValid = true;
        towersRequired.ForEach(skill =>
        {
            var towerNotValid = towersReceived.FirstOrDefault(s => s.ID == skill.ID);
            if (towerNotValid == null)
            {
                towersValid = false;
                return;
            }
            if (!towerNotValid.IsBought)
            {
                towersValid = false;
                return;
            }

        });
        return towersValid;
    }
    
}
