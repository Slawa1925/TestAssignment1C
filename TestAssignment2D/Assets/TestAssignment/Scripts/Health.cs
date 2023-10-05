using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int Hitpoints { get => hitpoints; }
    public float Ratio { get => (float)hitpoints / maxHitpoints; }
    public event Action OnHitpointChange;
    public event Action OnZeroHeath;
    [SerializeField] private int hitpoints;
    [SerializeField] private UnityEvent onTakeDamage;
    private int maxHitpoints;


    private void Awake()
    {
        maxHitpoints = hitpoints;
    }

    private void Start()
    {
        OnHitpointChange?.Invoke();
    }

    public void TakeDamage(int _damage)
    {
        hitpoints = Mathf.Clamp(hitpoints - _damage, 0, int.MaxValue);
        OnHitpointChange?.Invoke();
        onTakeDamage?.Invoke();

        if (hitpoints == 0)
        {
            OnZeroHeath?.Invoke();
        }
    }

    public void ResetHitpoints()
    {
        hitpoints = maxHitpoints;
        OnHitpointChange?.Invoke();
    }

    public void SetHitpoints(int _maxHitpoints)
    {
        maxHitpoints = _maxHitpoints;
    }
}
