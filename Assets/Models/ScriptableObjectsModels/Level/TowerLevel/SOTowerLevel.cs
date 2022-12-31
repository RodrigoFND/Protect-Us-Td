using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Scriptable Objects / Towers", order = 1)]
public class SOTowerLevel : ScriptableObject
{
    [SerializeField]
    protected int _id;
    [SerializeField]
    protected string _towerName;
    [SerializeField]
    protected Sprite _towerSprite;
    [SerializeField]
    protected GameObject _towerPreFab;
    [SerializeField]
    protected int _towerLevel;
    [SerializeField]
    protected int _pointsRequiredToUse = 0;
    [SerializeField]
    protected List<SOTowerLevel> _nextTowers = new List<SOTowerLevel>();
    [Header("Buy Tower Requirements")]
    [SerializeField]
    protected bool _isBought;
    [SerializeField]
    protected BuyTowerRequirements _buyTowerRequirements = new BuyTowerRequirements();
    public int ID => _id;
    public string TowerName => _towerName;
    public Sprite TowerSprite => _towerSprite;
    public GameObject TowerPrefab => _towerPreFab;
    public int TowerLevel => _towerLevel;
    public bool IsBought => _isBought;
    public int PointsRequiredToUse=> _pointsRequiredToUse;
    public List<SOTowerLevel> NextTowers => _nextTowers;



    public virtual void BuyTower(BuyTowerRequirements buyTowerRequirements)
    {
        if(CheckRequerimentsToBuy(buyTowerRequirements))
        {
            _isBought = true;
        }
    }

    public virtual bool CheckRequerimentsToBuy(BuyTowerRequirements buyTowerRequirements) {
        if (!_isBought) return false;
        return _buyTowerRequirements.CheckRequerimentsMatch(buyTowerRequirements);
    }

}
