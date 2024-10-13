using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCountText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myTMP;
    private bool canUpdate = true;
    void Start()
    {
        if (myTMP == null)
            myTMP = GetComponent<TextMeshProUGUI>();
        GameManager.instance.ballManager.onBallCountChanged += UpdateHUD;
        GameManager.instance.progressManager.onGameComplete += UpdateForEndGame;
    }

    private void UpdateHUD(int ballCount)
    {
        if(canUpdate)
            myTMP.text = GameManager.instance.gameModeSettings.thirdLineText + ballCount;
    }

    private void UpdateForEndGame(bool isWinner)
    {
        if (!isWinner)
        {
            canUpdate = false;
            myTMP.color = GameManager.instance.gameModeSettings.loseColor;
        }
        else
        {
            myTMP.color = myTMP.color = GameManager.instance.gameModeSettings.winColor;

        }
    }
}
