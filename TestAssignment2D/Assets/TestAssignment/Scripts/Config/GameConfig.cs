using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [System.Serializable]
    public struct FloatRange
    {
        public float min;
        public float max;
    }
    [System.Serializable]
    public struct IntRange
    {
        public int min;
        public int max;
    }

    [Header("Enemy")]
    public IntRange EnemyCount;
    public FloatRange EnemySpawnTimeout;
    public FloatRange EnemyMovementSpeed;
    public int EnemyHealth;

    [Header("Player")]
    public float ShotRadius;
    [Min(0)][SerializeField] private float ShotSpeed;
    public int ShotDamage;
    public float BulletFlySpeed;
    public float ShotInterval { get => ShotSpeed != 0 ? 1 / ShotSpeed : float.MaxValue; }
}
