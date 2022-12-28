using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Teste : MonoBehaviour
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
        OpenCanvas();
    }
  
    public void OnSelectionChanged(GameObject gameObject)
    {
        if(gameObject != this.gameObject)
        {
            CloseCanvas();
        }
    }

    private void CloseCanvas() => canvas.SetActive(false);
    private void OpenCanvas() => canvas.SetActive(true);
  



}
