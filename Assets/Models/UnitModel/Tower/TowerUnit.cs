using System.Linq;
using UnityEngine;

public class TowerUnit : Unit
{
    [SerializeField]
    private SOTowerData _towerData;


    void Awake()
    {
        _towerData = Instantiate(_towerData);
        _basicStatus = _towerData.TowerAttributes;
        _unitStateManager.StatusChangedAction(_basicStatus);
        _classSkills = _towerData.Skills.Where(s => s.IsBought).Select( s => Instantiate(s)).ToList();
        _unitStateManager.ClassSkillChangedAction(_classSkills);
        _unitStateManager.AnimatorChangedAction(_animator);
        ChangeUnitControl(true);
    }

}
