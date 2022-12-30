using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalStateManagerData
{
    public List<SOTowerLevel> towersChoosen = new List<SOTowerLevel>();
}

public  class GlobalStateManager: MonoBehaviour
{
    public static UnityAction<GameObject> gameObjectSelectionState;
    public static UnityAction<List<SOTowerLevel>> PlayersTowerState;
    public static GlobalStateManagerData stateData = new GlobalStateManagerData();
    public List<SOTowerLevel> towersChoosen = new List<SOTowerLevel>(); // Remover apos finalizar teste


    private void Awake()
    {
        stateData.towersChoosen = towersChoosen;
        DontDestroyOnLoad(this);
    }

    public static void SelectGameObjectAction(GameObject gameObject)
    {
        gameObjectSelectionState?.Invoke(gameObject);

    }

    public void UpdatePlayersTowerStateAction(List<SOTowerLevel> towersChoosen)
    {
        stateData.towersChoosen = towersChoosen ?? new List<SOTowerLevel>();
        PlayersTowerState?.Invoke(towersChoosen);
    }
}
