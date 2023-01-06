using UnityEngine;

public class TowerPlataform : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private TowerPlataformStateManager _towerPlataformStateManager;
    [SerializeField]
    private GameObject _towerInstatePosition;
    private GameObject _towerInPlace;
    private void OnEnable()
    {
        SceneStateManager.gameObjectSelectionState += OnPlataformSelectionChanged;
        _towerPlataformStateManager.SelectedTowerOnUIState += ChangeTower;
    }

    private void OnDisable()
    {
        SceneStateManager.gameObjectSelectionState -= OnPlataformSelectionChanged;
        _towerPlataformStateManager.SelectedTowerOnUIState -= ChangeTower;
    }

    public void OnMouseDown()
    {
        SceneStateManager.SelectGameObjectAction(this.gameObject);
        OpenTowerSelectionMenu();
    }

    private void ChangeTower(SOTowerLevel towerLevel) {
        if(_towerInPlace != null)
        {
            Destroy(_towerInPlace);
        }
        if (towerLevel == null)
        {
            Destroy(_towerInPlace);
            _towerPlataformStateManager.TowerChangedAction(towerLevel);
            return;
        }
        _towerInPlace = Instantiate(towerLevel.TowerPrefab, _towerInstatePosition.transform.position, Quaternion.identity);
        _towerInPlace.transform.SetParent(gameObject.transform);
        _towerPlataformStateManager.TowerChangedAction(towerLevel);
    }
  
    private void OnPlataformSelectionChanged(GameObject gameObject)
    {
        if(gameObject != this.gameObject)
        {
            CloseTowerSelectionMenu();
        }
    }

    private void CloseTowerSelectionMenu() => canvas.SetActive(false);
    private void OpenTowerSelectionMenu() => canvas.SetActive(true);
  
}
