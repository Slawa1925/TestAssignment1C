using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform target;
    private Vector3 lastTargetPos;
    private float speed;
    private int damage;


    public void Initialize(Transform _target, float _speed, int _damage)
    {
        target = _target;
        speed = _speed;
        damage = _damage;
    }

    private void Update()
    {
        if (target != null)
        {
            lastTargetPos = target.position;
        }

        transform.up = lastTargetPos - transform.position;
        transform.position += speed * Time.deltaTime * (lastTargetPos - transform.position).normalized;

        if (Vector3.Distance(lastTargetPos, transform.position) < 0.25f)
        {
            if (target != null)
            {
                target.GetComponent<Health>().TakeDamage(damage);
            }
            BulletManager.ReturnBullet(gameObject);
        }
    }
}
