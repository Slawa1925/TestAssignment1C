using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerStartPoint;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private FactoryStatic.EnemyManager enemyManager;


    private void Awake()
    {
        
    }

    public void Defeat()
    {
        Time.timeScale = 0;
        enemyManager.DisableEnemySpawn();
        gameUI.OnDefeat();
    }

    public void Victory()
    {
        Time.timeScale = 0;
        enemyManager.DisableEnemySpawn();
        gameUI.OnVictory();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        enemyManager.Restart();
        BulletManager.HideBullets();
        gameUI.OnRestart();
        playerTransform.position = playerStartPoint.position;
        playerHealth.ResetHitpoints();
    }
}
