using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Data", menuName = "Scriptable Objects / Data / Tower Data")]
public class SOTowerData : ScriptableObject
{
    [SerializeField]
    private TowerStatus _towerAttributes;
    [SerializeField]
    private List<SOSkills> _skills = new List<SOSkills>();

    public TowerStatus TowerAttributes => _towerAttributes;
    public List<SOSkills> Skills => _skills;
}
