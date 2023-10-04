using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private FactoryStatic.EnemyManager enemyManager;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletFlySpeed;
    [SerializeField] private float radius;
    [SerializeField] private float shotingInterval = 1.0f;
    private float timer;
    private Transform target;
    //private float shotingInterval { get => shotingInterval; set { shotingInterval = 1 / shotingSpeed; } }
    [SerializeField] private int bulletDamage;

    [SerializeField] private Transform[] enemies;


    private void Update()
    {
        if (timer <= 0)
        {
            target = GetClosestEnemy();
            if (target != null)
            {
                Shoot();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private Transform GetClosestEnemy()
    {
        Transform _closestEnemy = null;
        float _minDistance = Mathf.Infinity;
        foreach (FactoryStatic.Enemy _enemy in enemyManager.Enemies)
        {
            var _distance = Vector3.Distance(_enemy.transform.position, transform.position);
            if (_distance < radius)
            {
                if (_distance < _minDistance)
                {
                    _minDistance = _distance;
                    _closestEnemy = _enemy.transform;
                }
            }
        }

        return _closestEnemy;
    }

    private void Shoot()
    {
        var _bullet = BulletManager.GetBullet();
        _bullet.transform.position = transform.position;
        _bullet.GetComponent<BulletController>().Initialize(target, bulletFlySpeed, bulletDamage);
        timer = shotingInterval;
    }
}
