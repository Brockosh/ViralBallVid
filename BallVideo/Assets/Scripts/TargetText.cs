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
        myTMP.text = $"Target: {GameManager.instance.gameModeSettings.amountOfBallsToWin}";
    }


    private void UpdateText(bool isWinner)
    {
        if (isWinner)
        {
            myTMP.text = "Success!";
            myTMP.color = winnerColor;
        }
        else
        {
            myTMP.text = "Failed!";
            myTMP.color = loserColor;
        }

    }
}
