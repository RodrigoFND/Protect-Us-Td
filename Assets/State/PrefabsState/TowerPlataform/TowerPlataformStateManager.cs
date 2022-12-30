using UnityEngine;
using UnityEngine.Events;

public class TowerPlataformsStateManagerData
{
    public SOTowerLevel TowerSelected;
    public SOTowerLevel TowerChanged;
}
public class TowerPlataformStateManager : MonoBehaviour
{
    public UnityAction<SOTowerLevel> SelectedTowerOnUIState;
    public UnityAction<SOTowerLevel> TowerChangedState;
    public TowerPlataformsStateManagerData TowerPlataformDataState { get; private set; } = new TowerPlataformsStateManagerData();

    public void SelectedTowerOnUIStateAction(SOTowerLevel tower)
    {
        TowerPlataformDataState.TowerSelected = tower;
        SelectedTowerOnUIState?.Invoke(tower);
    }

    public void TowerChangedAction(SOTowerLevel tower)
    {
        TowerPlataformDataState.TowerChanged = tower;
        TowerChangedState?.Invoke(tower);
    }
}
