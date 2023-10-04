using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryStatic
{
    public class EnemyManager : MonoBehaviour
    {
        public List<Enemy> Enemies { get => enemies; }
        public float DestinationPos { get => finishLine.position.y; }
        public int EnemiesToKill { get => enemiesToKill; }
        public Health PlayerHealth;
        [SerializeField] private List<Enemy> enemies;
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private Transform finishLine;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private EnemySpawner[] spawners;
        [SerializeField] private int minEnemyCount;
        [SerializeField] private int maxEnemyCount;
        private int enemiesToKill;


        private void Awake()
        {
            enemiesToKill = Random.Range(minEnemyCount, maxEnemyCount);
        }

        public void Restart()
        {
            enemiesToKill = Random.Range(minEnemyCount, maxEnemyCount);
            foreach (Enemy _enemy in enemies)
            {
                Destroy(_enemy.gameObject);
            }

            enemies.Clear();

            EnableEnemySpawn();
        }

        public void EnableEnemySpawn()
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].gameObject.SetActive(true);
            }
        }

        public void DisableEnemySpawn()
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].gameObject.SetActive(false);
            }
        }

        public void AddEnemy(Enemy _enemy)
        {
            enemies.Add(_enemy);
        }

        public void RemoveEnemy(Enemy _enemy)
        {
            enemies.Remove(_enemy);
        }

        public void UpdateKillCount()
        {
            enemiesToKill--;
            if (enemiesToKill < 0)
            {
                gameManager.Victory();
            }
        }
    }
}