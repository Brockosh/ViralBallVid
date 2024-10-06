using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField]
    private int amountOfBallsToWin;
    [SerializeField]
    private int amountOfTimeInSeconds;
    [SerializeField]
    private float timeBetweenDecrement = 1;
    [SerializeField]
    private Color fillColor;

    public int AmountOfTimeInSeconds {  get { return amountOfTimeInSeconds; } }
    public int AmountOfBallsToWIn {  get { return amountOfBallsToWin; } }

    public event Action<float> onProgressUpdated;
    public event Action<int> onTimeRemainingUpdated;
    public event Action<Color> onUpdateProgressColor;
    public event Action<bool> onGameComplete;

    private void Start()
    {
        GameManager.instance.ballManager.onBallCountChanged += CalculateProgress;
        onTimeRemainingUpdated += CheckGameOver;
        onTimeRemainingUpdated?.Invoke(amountOfTimeInSeconds);
        onUpdateProgressColor?.Invoke(fillColor);
        StartCountDown();
    }

    private void StartCountDown()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while (amountOfTimeInSeconds > 0)
        {
            amountOfTimeInSeconds--;
            onTimeRemainingUpdated?.Invoke(amountOfTimeInSeconds);
            yield return new WaitForSeconds(timeBetweenDecrement);
        }
    }

    private void CalculateProgress(int currentBallCount)
    {
        float progressPercentage = ((float)currentBallCount / (float)amountOfBallsToWin) * 100f;
        onProgressUpdated?.Invoke(progressPercentage);

        if (progressPercentage == 100)
        {
            onGameComplete?.Invoke(true);
        }
        Debug.Log(progressPercentage);
    }

    private void CheckGameOver(int timeRemaining)
    {
        if (timeRemaining == 0)
        {
            onGameComplete?.Invoke(false);
        }
    }
}
