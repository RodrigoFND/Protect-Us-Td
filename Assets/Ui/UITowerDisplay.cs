using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TowerDisplay
{
    public Button towerButton;
    public Image towerImage;
    public TMP_Text towerText;
}
public class UITowerDisplay : MonoBehaviour
{
    [SerializeField]
    private TowerPlataformStateManager _towerPlataformStateManager;
    [SerializeField]
    private Button RemoveTowerButton;
    private List<SOTowerLevel> towers = new List<SOTowerLevel>();
    public List<TowerDisplay> towerUiDisplay = new List<TowerDisplay>();

    public void OnEnable()
    {
        _towerPlataformStateManager.TowerChangedState += onTowerChanged;
        ChangeUiDisplay();
    }

    public void OnDisable()
    {
        _towerPlataformStateManager.TowerChangedState -= onTowerChanged;
    }

    public void Start()
    {
        InitializeTowers();
        ChangeUiDisplay();
    }

    private void onTowerChanged(SOTowerLevel tower)
    {
        if(tower == null)
        {
            ToogleTrashButtonDisplay(false);
            InitializeTowers();
        } else
        {
            ToogleTrashButtonDisplay(true);
            towers = tower.NextTowers.ToList();
        }
        ChangeUiDisplay();

    }

    private void ChangeUiDisplay()
    {
       foreach (var display in towerUiDisplay.Select((ui,index) => (ui,index)))
        {
            if(towers.Count <= display.index)
            {
                display.ui.towerButton.gameObject.SetActive(false);
                continue;
            }
            var towerFound = towers[display.index];
            if (towerFound != null)
            {
                display.ui.towerButton.gameObject.SetActive(true);
                display.ui.towerImage.sprite = towerFound.TowerSprite;
                display.ui.towerText.text = towerFound.PointsRequiredToUse.ToString();
                display.ui.towerButton.onClick.RemoveAllListeners();
                display.ui.towerButton.onClick.AddListener(() => _towerPlataformStateManager.SelectedTowerOnUIStateAction(towerFound));
            }
        }
    }

    private void ToogleTrashButtonDisplay(bool showTrashButton)
    {
        RemoveTowerButton.gameObject.SetActive(showTrashButton);
    }

    private void InitializeTowers()
    {
       var tower = _towerPlataformStateManager.TowerPlataformDataState.TowerChanged;
        if(tower != null)
        {
            towers = tower.NextTowers.ToList();
        } else
        {
            towers = GlobalStateManager.stateData.towersChoosen;
        }
    }

    public void OnTrashButtonPressed()
    {
        _towerPlataformStateManager.SelectedTowerOnUIStateAction(null);
    }

}
