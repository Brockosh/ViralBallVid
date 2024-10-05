using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CountDownText : MonoBehaviour
{
    [SerializeField]
    private int countDownValue = 60;
    [SerializeField]
    private float timeBetweenDecrement = 1;
    private TextMeshProUGUI myTMP;

    private void Start()
    {
        if (myTMP == null)
            myTMP = GetComponent<TextMeshProUGUI>();
        StartCountDown();
    }

    private void StartCountDown()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {

        while (countDownValue > 0) 
        { 
            UpdateHUD(countDownValue);
            countDownValue--;
            yield return new WaitForSeconds(timeBetweenDecrement);
        }
    }

    private void UpdateHUD(int value)
    {
        myTMP.text = $"Time Remaining: {value.ToString()}";
    }
}
