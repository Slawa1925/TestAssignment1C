using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    public abstract void Setup(EnemyManager _enemyManager);
    public abstract void Die();
}