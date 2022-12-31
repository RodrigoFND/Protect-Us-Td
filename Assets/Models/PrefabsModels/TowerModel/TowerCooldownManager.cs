using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerCooldownManager : MonoBehaviour
{

    [SerializeField]
    private TowerStateManager _towerStateManager;
    [SerializeField]
    private List<SOSkills> _skills = new List<SOSkills>();


    private void OnEnable()
    {
        _towerStateManager.TowerSkillsChangedState += (skills) => _skills = skills;
    }
 

    // Update is called once per frame
    void LateUpdate()
    {
        setSkillsCoolDown();
    }

    private void setSkillsCoolDown()
    {
        _skills.ForEach(skill =>
        {
            Debug.Log(skill.SkillCountDownTimeElapsed);
            if (skill.SkillCountDownTimeElapsed <= 0)
            {
                // skill ready to be used
            }
            else skill.SkillCountDownTimeElapsed -= Time.deltaTime;
        });
    }

}
