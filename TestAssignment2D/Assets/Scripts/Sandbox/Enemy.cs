using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryStatic
{
    public abstract class Enemy : MonoBehaviour
    {
        public abstract void Setup(EnemyManager _enemyManager,float _speed);
        public abstract void Die();
    }
}
