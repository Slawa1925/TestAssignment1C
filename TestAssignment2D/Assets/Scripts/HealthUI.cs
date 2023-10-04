using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Health health;

    public void UpdateText()
    {
        healthText.text = "Здоровье: " + health.Hitpoints;
    }
}
