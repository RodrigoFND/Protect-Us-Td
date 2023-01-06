using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable :MonoBehaviour, IHittable
{
    //[SerializeField]
    //private UnitStateManager _unitStateManager;
    //private UnitExternalReference unitExternalReference;
    private GameObject _hittableComponent;
    public GameObject HittableComponent => _hittableComponent;
    //private void OnEnable()
    //{
    //    _unitStateManager.ExternalReferenceChangeState += SetUnitExternalReference;
    //}
    //private void OnDisable()
    //{
    //    _unitStateManager.ExternalReferenceChangeState -= SetUnitExternalReference;
    //}

    private void Start()
    {
        _hittableComponent = gameObject;
    }

    //private void SetUnitExternalReference(UnitExternalReference unitExternalReference)
    //{
    //    this.unitExternalReference = unitExternalReference;
    //}

    public void HitComponent(int hit)
    {
    }
}
