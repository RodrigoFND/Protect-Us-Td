using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSingleton : MonoBehaviour
{
    public static UnityAction PointsChangeState;
    public static UnityAction TowersChoosenChangeState;
    [SerializeField]
  private static int _points;
    [SerializeField]
    private static List<SOTowerLevel> _towersChoosen = new List<SOTowerLevel>();
    [SerializeField]
    private  List<SOTowerLevel> _towersChoosenTest = new List<SOTowerLevel>();

    public static int Points => _points;
    public static List<SOTowerLevel> TowersChoosen => _towersChoosen;


    private void Awake()
    {
        _towersChoosen = _towersChoosenTest;
        DontDestroyOnLoad(this);
    }

    public static void UpdatePoints(int points)
    {
        _points = points;
        _points = _points > 0 ? _points : 0;
        PointsChangeState?.Invoke();
    }
    public static void SetTowersSelected(List<SOTowerLevel> towersChoosen)
    {
        _towersChoosen = towersChoosen ?? new List<SOTowerLevel>();
        TowersChoosenChangeState?.Invoke();
    }

}
