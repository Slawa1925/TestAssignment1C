using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private GameConfig config;
    private float timer;


    private void Awake()
    {
        timer = Random.Range(config.EnemySpawnTimeout.min, config.EnemySpawnTimeout.max);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = Random.Range(config.EnemySpawnTimeout.min, config.EnemySpawnTimeout.max);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        var _enemy = EnemyFactory.GetEnemy();
        _enemy.Setup(enemyManager);
        _enemy.transform.position = transform.position;
        enemyManager.AddEnemy(_enemy);
    }
}
