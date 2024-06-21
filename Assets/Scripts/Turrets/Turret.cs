
using System;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float _health;
    private Transform _target;
    
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private CircleCollider2D _collider;
    
    
    [Header("Attribute")]
    [SerializeField] private float targetRange = 4f;
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _collider.radius = targetRange + 2;
        if (_target == null)
        {
            // FindTarget();
            return;
        }


        RotateTowardsTarget();
        if (!CheckTargetInRange())
        {
            _target = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _target = other.transform;
    }

    bool CheckTargetInRange()
    {
        return Vector2.Distance(_target.position, transform.position) <= targetRange;
    }

    void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) *
                      Mathf.Rad2Deg + 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


    // void FindTarget()
    // {
    //     RaycastHit2D hits = Physics2D.CircleCast(transform.position, targetRange, transform.position, 0f, enemyMask);
    //     if (hits)
    //     {
    //         _target = hits.transform;
    //     }
    // }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }
}
