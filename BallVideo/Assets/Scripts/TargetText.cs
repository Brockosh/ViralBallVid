using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myTMP;
    private Color winnerColor;
    private Color loserColor;

    private void Start()
    {
        if (myTMP == null)
        {
            myTMP = GetComponent<TextMeshProUGUI>();
        }

        GameManager.instance.progressManager.onGameComplete += UpdateText;
        winnerColor = GameManager.instance.gameModeSettings.winColor;
        loserColor = GameManager.instance.gameModeSettings.loseColor;
        myTMP.text = GameManager.instance.gameModeSettings.firstLineText;
    }


    private void UpdateText(bool isWinner)
    {
        if (isWinner)
        {
            myTMP.text = GameManager.instance.gameModeSettings.winningText;
            myTMP.color = winnerColor;
        }
        else
        {
            myTMP.text = GameManager.instance.gameModeSettings.losingText;
            myTMP.color = loserColor;
        }

    }
}
