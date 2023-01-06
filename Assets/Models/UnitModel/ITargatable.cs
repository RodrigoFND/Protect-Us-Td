using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargatable
{
    LayerMask ComponentLayer { get; }
    LayerMask LayerToFocus { get; set; }
    List<UnitExternalReference> AllTargetInRange { get; }
    UnitExternalReference ClosestTarget { get; }
    UnitExternalReference LockedTarget { get; }

    public void SearchTargetsAround();
    public void SearchClosestTarget();
    public void LockClosestTarget(bool keepLastReference);

}
