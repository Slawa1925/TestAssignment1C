using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryStatic
{
    public class NormalEnemy : Enemy
    {
        private EnemyManager enemyManager;
        private float speed;

        public override void Die()
        {
            enemyManager.RemoveEnemy(this);
            enemyManager.UpdateKillCount();
            Destroy(gameObject);
        }

        public override void Setup(EnemyManager _enemyManager, float _speed)
        {
            enemyManager = _enemyManager;
            speed = _speed;
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
    }
}