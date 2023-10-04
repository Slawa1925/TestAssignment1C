using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int Hitpoints { get => hitpoints; }
    [SerializeField] private int hitpoints;
    private int maxHitpoints;
    [SerializeField] private UnityEvent onHitpointChange;
    [SerializeField] private UnityEvent onZeroHeath;


    private void Awake()
    {
        maxHitpoints = hitpoints;
    }

    private void Start()
    {
        onHitpointChange?.Invoke();
    }

    public void TakeDamage(int _damage)
    {
        hitpoints = Mathf.Clamp(hitpoints - _damage, 0, int.MaxValue);
        onHitpointChange?.Invoke();

        if (hitpoints == 0)
        {
            onZeroHeath?.Invoke();
        }
    }

    public void ResetHitpoints()
    {
        hitpoints = maxHitpoints;
        onHitpointChange?.Invoke();
    }
}
