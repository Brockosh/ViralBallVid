using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CountDownText : MonoBehaviour
{
    private TextMeshProUGUI myTMP;
    private bool isGameOver = false;

    private void Start()
    {
        if (myTMP == null)
            myTMP = GetComponent<TextMeshProUGUI>();
        UpdateHUD(GameManager.instance.progressManager.AmountOfTimeInSeconds);
        GameManager.instance.progressManager.onTimeRemainingUpdated += UpdateHUD;
        GameManager.instance.progressManager.onGameComplete += UpdateForEndGame;
    }

    private void UpdateHUD(int value)
    {
        if (!isGameOver)
            myTMP.text = GameManager.instance.gameModeSettings.secondLineText + value;
    }

    private void UpdateForEndGame(bool isWinner)
    {
        isGameOver = true;
    }

}
