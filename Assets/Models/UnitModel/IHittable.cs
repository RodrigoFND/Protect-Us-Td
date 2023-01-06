using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    GameObject HittableComponent
    {
        get;
    }

    void HitComponent(int hit);
}
