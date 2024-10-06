using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myTMP;
    [SerializeField]
    private Color winnerColor;
    [SerializeField]
    private Color loserColor;

    private void Start()
    {
        if (myTMP == null)
        {
            myTMP = GetComponent<TextMeshProUGUI>();
        }

        GameManager.instance.progressManager.onGameComplete += UpdateText;
        myTMP.text = $"Target: {GameManager.instance.progressManager.AmountOfBallsToWIn}";
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
