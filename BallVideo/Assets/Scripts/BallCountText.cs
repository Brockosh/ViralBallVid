using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCountText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myTMP;
    [SerializeField]
    private Color winnerColor;
    [SerializeField]
    private Color loserColor;
    private bool isGameOver = false;
    void Start()
    {
        if (myTMP == null)
            myTMP = GetComponent<TextMeshProUGUI>();
        GameManager.instance.ballManager.onBallCountChanged += UpdateHUD;
        GameManager.instance.progressManager.onGameComplete += UpdateForEndGame;
    }

    private void UpdateHUD(int ballCount)
    {
        if(!isGameOver)
            myTMP.text = $"Ball Count: {ballCount}";
    }

    private void UpdateForEndGame(bool isWinner)
    {
        isGameOver = true;
        myTMP.text = myTMP.text = $"Ball Count: {GameManager.instance.ballManager.BallCount}";
        if (!isWinner)
        {
            myTMP.color = loserColor;
        }
        else
        {
            myTMP.color = winnerColor;
        }
    }
}
