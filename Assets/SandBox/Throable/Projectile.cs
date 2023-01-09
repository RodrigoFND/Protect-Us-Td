using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    
    private Rigidbody rb;
    [SerializeField]
    private SOProjectileSkill _skill;
    public UseSkillRequirements _useSkillRequirements;
    public GameObject _target;
    private Vector3 _targetLastPosition;
    private float _speed;
    void Start()
    {
      rb = GetComponent<Rigidbody>();

        _target = _skill.Target;
        _useSkillRequirements = _skill.UseSkillRequerimentsProjectileReference;
        _speed = _skill.Speed;

    }

    private void OnDestroy()
    {
        Destroy(_skill);
        
    }

    public void SetSkill(SOProjectileSkill skill)
    {
        _skill = Instantiate(skill);

    }

    public void SetSkillRequirements(UseSkillRequirements useSkillRequirements)
    {
        _useSkillRequirements = useSkillRequirements;
    }
    private void CopyTargetLastPosition(GameObject transformToCopy)
    {
        if (transformToCopy == null) return;
        _targetLastPosition = transformToCopy.transform.position;
    }

    void Update()
    {
        CopyTargetLastPosition(_target);
        if (_target != null) GoToTheTarget(_target.transform.position);
        else GoToTheTarget(_targetLastPosition);
        DestroyWhenReachTarget();

    }

    private void GoToTheTarget(Vector3 targetPosition)
    {
        try
        {
            Vector3 dir = (targetPosition - transform.position).normalized;
            Vector3 deltaPosition = _speed * dir * Time.deltaTime;
            rb.MovePosition(transform.position + deltaPosition);
            transform.LookAt(targetPosition);
        }
        catch { }
    }

    private void DestroyWhenReachTarget()
    {
        var checkHitTheTarget = (_targetLastPosition - transform.position).sqrMagnitude < 0.2;
        if (_targetLastPosition != null && checkHitTheTarget)
        {
            _skill.InitializeSkillHitEffect(_useSkillRequirements);
            Destroy(gameObject);
        
        }
    }
}
