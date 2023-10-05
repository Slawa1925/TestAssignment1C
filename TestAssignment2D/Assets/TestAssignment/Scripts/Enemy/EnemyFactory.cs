using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public static Enemy GetEnemy()
    {
        return Instantiate(staticEnemyPrefab, defaultTransform).GetComponent<Enemy>();
    }
}
