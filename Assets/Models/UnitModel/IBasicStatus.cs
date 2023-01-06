using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBasicStatus 
{
    int GetHp();
    int GetAtkSpeed();
    void SetHp(int amount);

}
