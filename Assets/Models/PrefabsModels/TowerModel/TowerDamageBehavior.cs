using System.Collections.Generic;
using UnityEngine;

public class  TowerDamageBehavior : DamageBehavior
{
    [SerializeField]
    private TowerStateManager _towerStateManager;
    private List<SOSkills> _skills = new List<SOSkills>();


    // Start is called before the first frame update
    private void OnEnable()
    {
        _towerStateManager.TowerSkillsChangedState += (skills) => _skills = skills;
    }

    // Update is called once per frame
    void Update()
    {
       
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _skills[0].useSkill(null);
        //        _skills[0].ResetSkillCountDownTimeElapsed();
        //    }
        

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    ApplyDamage(20);

        //}
        
    }

    public override void ApplyDamage(int damage)
    {
        _towerStateManager.TowerHittedAction(-damage);
    }
}
