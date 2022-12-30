using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Scriptable Objects / Towers", order = 1)]
public class SOTowerLevel : ScriptableObject
{
    [SerializeField]
    private string towerName;
    [SerializeField]
    private Sprite towerSprite;
    [SerializeField]
    private GameObject _towerPreFab;
    [SerializeField]
    private int _towerLevel;
    private bool _canBeBought;
    [SerializeField]
    private bool _isbought;
    [SerializeField]
    private List<SOTowerLevel> _towersRequired = new List<SOTowerLevel>();
    [SerializeField]
    private int _pointsRequiredToBuy = 0;
    [SerializeField]
    private int _pointsRequiredToUse = 0;
    [SerializeField]
    private List<SOTowerLevel> _nextTowers = new List<SOTowerLevel>();

    public string TowerName => towerName;
    public Sprite TowerSprite => towerSprite;
    public GameObject TowerPrefab => _towerPreFab;
    public int TowerLevel => _towerLevel;
    public bool CanBeBought => _canBeBought;
    public bool IsBought => _isbought;
    public int PointsRequiredToBuy => _pointsRequiredToBuy;
    public int PointsRequiredToUse=> _pointsRequiredToUse;
    public List<SOTowerLevel> NextTowers => _nextTowers;



    public virtual void BuyTower(int points)
    {
        if(CheckRequerimentsToBuy(points))
        {
            _isbought = true;
        }
    }

    public virtual bool CheckRequerimentsToBuy(int points) { 
        if(points < _pointsRequiredToBuy)
        {
            Debug.Log("Not enought points to buy");
            return false;
        }
        SOTowerLevel towerNotBought = _towersRequired.FirstOrDefault(tower => tower.IsBought == false);

        if (towerNotBought != null)
        {
            Debug.Log(towerNotBought.TowerName + " - required;");
            return false;
        }
        return true;
    }

}
