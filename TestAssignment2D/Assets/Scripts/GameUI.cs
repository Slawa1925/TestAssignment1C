using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject defeatWindow;
    [SerializeField] private GameObject victoryWindow;


    public void OnVictory()
    {
        victoryWindow.SetActive(true);
    }

    public void OnDefeat()
    {
        defeatWindow.SetActive(true);
    }

    public void OnRestart()
    {
        victoryWindow.SetActive(false);
        defeatWindow.SetActive(false);
    }
}
