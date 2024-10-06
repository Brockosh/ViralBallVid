using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CountDownText : MonoBehaviour
{
    private TextMeshProUGUI myTMP;

    private void Start()
    {
        if (myTMP == null)
            myTMP = GetComponent<TextMeshProUGUI>();
        UpdateHUD(GameManager.instance.progressManager.AmountOfTimeInSeconds);
        GameManager.instance.progressManager.onTimeRemainingUpdated += UpdateHUD;
    }

    private void UpdateHUD(int value)
    {
        myTMP.text = $"Time Remaining: {value}";
    }
}
