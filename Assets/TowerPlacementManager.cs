using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class TowerPlacerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    private void OnEnable()
    {
        GlobalStateHandler.gameObjectSelectionState += OnSelectionChanged;
    }
    private void Awake()
    {
        


    }
    //Do this when the selectable UI object is selected.

    public void OnMouseDown()
    {
        GlobalStateHandler.SelectGameObjectAction(this.gameObject);
        OpenTowerSelectionMenu();
    }
  
    public void OnSelectionChanged(GameObject gameObject)
    {
        if(gameObject != this.gameObject)
        {
            CloseTowerSelectionMenu();
        }
    }

    private void CloseTowerSelectionMenu() => canvas.SetActive(false);
    private void OpenTowerSelectionMenu() => canvas.SetActive(true);
  



}
