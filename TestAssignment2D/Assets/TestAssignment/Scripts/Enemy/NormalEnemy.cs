using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NormalEnemy : Enemy
{
    [SerializeField] private GameConfig config;
    private EnemyManager enemyManager;
    private Health health;
    private float speed;


    private void Awake()
    {
        if (health == null)
        {
            health = GetComponent<Health>();
        }
    }

    public override void Die()
    {
        enemyManager.RemoveEnemy(this);
        enemyManager.UpdateKillCount();
        Destroy(gameObject);
    }

    public override void Setup(EnemyManager _enemyManager)
    {
        enemyManager = _enemyManager;
        speed = Random.Range(config.EnemyMovementSpeed.min, config.EnemyMovementSpeed.max);
        health.SetHitpoints(config.EnemyHealth);
        health.OnZeroHeath += Die;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;

        if (transform.position.y < enemyManager.DestinationPos)
        {
            EnterFinishLine();
        }
    }

    private void EnterFinishLine()
    {
        enemyManager.PlayerHealth.TakeDamage(1);
        enemyManager.RemoveEnemy(this);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        health.OnZeroHeath -= Die;
    }
}