using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public static class GlobalStateHandler
{
    public static UnityAction<GameObject> gameObjectSelectionState;
    // Start is called before the first frame update
    


    public static void SelectGameObjectAction(GameObject gameObject)
    {
        gameObjectSelectionState?.Invoke(gameObject);

    }
}
