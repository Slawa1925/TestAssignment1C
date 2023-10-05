using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private GameConfig config;
    private float timer;
    private Transform target;


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
        foreach (Enemy _enemy in enemyManager.Enemies)
        {
            var _distance = Vector3.Distance(_enemy.transform.position, transform.position);
            if (_distance < config.ShotRadius)
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
        _bullet.GetComponent<BulletController>().Initialize(target, config.BulletFlySpeed, config.ShotDamage);
        timer = config.ShotInterval;
    }
}
