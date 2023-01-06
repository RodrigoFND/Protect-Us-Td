using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealable
{
    bool CanHealHP { get; set; }
    public void HealHP(int amount);
}
