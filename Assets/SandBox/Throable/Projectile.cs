using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public GameObject _target;
    [SerializeField]

    private GameObject _projectileComponent;
    private Vector3 _targetLastPosition;
    [SerializeField]
    public int speed;
    [SerializeField]
    public Rigidbody rb;
    private bool _hasColidded = false;
    [SerializeField]
    private float _destroyTimeAfterCollide = 3;
    

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 800 * Time.deltaTime,Space.World);
        transform.position += transform.forward * speed * Time.deltaTime;
        //if (_target != null) GoToTheTarget(_target.transform.position);
        //else rb.AddForce(transform.forward * speed);
        //if (_hasColidded) Destroy(gameObject);
        //CopyTargetLastPosition(_target);
    }

    private void CopyTargetLastPosition (GameObject transformToCopy)
    {
        if (transformToCopy == null) return;
        _targetLastPosition = transformToCopy.transform.position;
    }

    private void GoToTheTarget(Vector3 targetPosition)
    {
        try
        {
            rb.AddForce(transform.forward * speed);
            transform.LookAt(_target.transform.position);

            //Vector3 dir = (targetPosition - transform.position).normalized;
            //Vector3 deltaPosition = speed * dir * Time.deltaTime;
            //rb.MovePosition(transform.position + deltaPosition);
            //transform.LookAt(targetPosition);

        } catch { }
   
     
      
    }


    private void OnTriggerEnter(Collider other)
    {
        StopWhenColideWithTerrain(other);
        StopWhenColideWithTarget(other);
    }

    private void StopWhenColideWithTarget(Collider other)
    {
        if (_target != null && other.transform.gameObject == _target.transform.gameObject)
        {
            Debug.Log("i collide");
            transform.SetParent(other.transform);
            speed = 0;
            rb.isKinematic = true;
            _hasColidded = true;
        }

    }



    private void StopWhenColideWithTerrain(Collider other)
    {
        if (other is TerrainCollider)
        {
            Debug.Log("Terrain Collider");
            speed = 0;
            rb.isKinematic = true;
            _hasColidded = true;
        }

    }

}
