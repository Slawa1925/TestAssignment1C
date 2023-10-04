using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryStatic
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject normalEnemy;
        private static GameObject staticEnemyPrefab;
        private static Transform defaultTransform;


        private void Awake()
        {
            staticEnemyPrefab = normalEnemy;
            defaultTransform = transform;
        }

        public static Enemy GetEnemy(string enemyType)
        {
            return enemyType switch
            {
                "normal" => Instantiate(staticEnemyPrefab, defaultTransform).GetComponent<Enemy>(),
                _ => null,
            };
        }
    }
}
