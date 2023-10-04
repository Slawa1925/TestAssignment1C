using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private FactoryStatic.EnemyManager enemyManager;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float minEnemySpeed;
    [SerializeField] private float maxEnemySpeed;
    private float timer;


    private void Awake()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = Random.Range(minSpawnTime, maxSpawnTime);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        var _enemy = FactoryStatic.EnemyFactory.GetEnemy("normal");
        _enemy.Setup(enemyManager, Random.Range(minEnemySpeed, maxEnemySpeed));
        _enemy.transform.position = transform.position;
        enemyManager.AddEnemy(_enemy);
    }
}
