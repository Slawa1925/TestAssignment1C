using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        health.TakeDamage(4);
    }
}
