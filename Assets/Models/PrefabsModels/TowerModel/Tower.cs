using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour, IBasicStatus
{
    [SerializeField]
    private TowerStateManager _towerStateManager;
    [SerializeField]
    private SOTowerData _towerData;
    [SerializeField] //Remover apos teste
    private TowerStatus _towerStatus = new TowerStatus();
    private List<SOSkills> _towerSkills = new List<SOSkills>();

    private void OnEnable()
    {
        _towerStateManager.TowerHittedState += SetHP;
    }

    private void OnDisable()
    {
        _towerStateManager.TowerHittedState -= SetHP;
    }
    // Start is called before the first frame update
    void Awake()
    {
        _towerData = Instantiate(_towerData);
        _towerStatus = _towerData.TowerAttributes;
        _towerStateManager.TowerStatusChangedAction(_towerStatus);
        _towerSkills = _towerData.Skills.Where(s => s.IsBought).Select( s => Instantiate(s)).ToList();
        _towerStateManager.TowerSkillsChangedAction(_towerSkills);
    }

  

    private void SetHP(int hpAmout)
    {
        _towerStatus.HP += hpAmout;
        _towerStatus.HP = _towerStatus.HP > 0 ? _towerStatus.HP : 0;
        _towerStateManager.TowerStatusChangedAction(_towerStatus);
    }

    private void SetMP(int mpAmout)
    {
        _towerStatus.MP += mpAmout;
        _towerStatus.MP = _towerStatus.MP > 0 ? _towerStatus.MP : 0;
        _towerStateManager.TowerStatusChangedAction(_towerStatus);
    }

    private void SetPAttack(int pAttack)
    {
        _towerStatus.PhysicalAttack += pAttack;
        _towerStatus.PhysicalAttack = _towerStatus.PhysicalAttack > 0 ? _towerStatus.PhysicalAttack : 0;
        _towerStateManager.TowerStatusChangedAction(_towerStatus);
    }

    public void MyTEST()
    {
        IBasicStatus TEST = new()
        throw new System.NotImplementedException();
    }
}
