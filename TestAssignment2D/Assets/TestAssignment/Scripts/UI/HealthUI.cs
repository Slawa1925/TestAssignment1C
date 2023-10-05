using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Health health;
    [SerializeField] private Image barImage;


    private void Awake()
    {
        health.OnHitpointChange += UpdateText;
    }

    private void OnDisable()
    {
        health.OnHitpointChange -= UpdateText;
    }

    public void UpdateText()
    {
        healthText.text = "Здоровье: " + health.Hitpoints;
        barImage.fillAmount = health.Ratio;
    }
}
