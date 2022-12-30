using UnityEngine;
using UnityEngine.Events;



public class SceneStateManager : MonoBehaviour
{
    public static UnityAction<GameObject> gameObjectSelectionState;
 
    public static void SelectGameObjectAction(GameObject gameObject)
    {
        gameObjectSelectionState?.Invoke(gameObject);

    }
}
