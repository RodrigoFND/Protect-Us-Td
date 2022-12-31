using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TowerSkillManager : SkillManager
{

    [SerializeField]
    private TowerStateManager _towerStateManager;


    private void OnEnable()
    {
        _towerStateManager.TowerSkillsChangedState += (skills) => _internalDataSkills = skills;
    }
 

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
     
    }

}
