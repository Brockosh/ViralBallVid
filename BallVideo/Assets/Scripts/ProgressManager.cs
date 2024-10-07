using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    private int startingAmountOfTime;
    private float timePassedSinceGameStarted;

    private bool hasFirstBallEscaped = false;
    private float timeBeforeFirstBallEscaped;

    private bool isGameOver;

    public int AmountOfTimeInSeconds {  get { return amountOfTimeInSeconds; } }
    public int AmountOfBallsToWIn {  get { return amountOfBallsToWin; } }

    public event Action<float> onProgressUpdated;
    public event Action<int> onTimeRemainingUpdated;
    public event Action<Color> onUpdateProgressColor;
    public event Action<bool> onGameComplete;

    private void Start()
    {
        GameManager.instance.ballManager.onBallCountChanged += CalculateProgress;
        GameManager.instance.ballManager.onBallCountChanged += UnsubscribeBallEscapeCounter;

        startingAmountOfTime = amountOfTimeInSeconds;

        onTimeRemainingUpdated += CheckGameOver;
        onTimeRemainingUpdated?.Invoke(amountOfTimeInSeconds);
        onUpdateProgressColor?.Invoke(fillColor);
        StartCountDown();
    }

    private void Update()
    {
        timePassedSinceGameStarted += Time.deltaTime;

        if (!hasFirstBallEscaped)
            timeBeforeFirstBallEscaped += Time.deltaTime;
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
            if (!isGameOver)
            {
                isGameOver = true;
                onGameComplete?.Invoke(true);
                CalculateGameStatistics();
            }
        }
        Debug.Log(progressPercentage);
    }

    private void CheckGameOver(int timeRemaining)
    {
        if (timeRemaining == 0)
        {
            if (!isGameOver)
            {
                isGameOver = true;
                onGameComplete?.Invoke(false);
                CalculateGameStatistics();
            }
        }
    }

    private void UnsubscribeBallEscapeCounter(int ballCount)
    {
        hasFirstBallEscaped = true;
        GameManager.instance.ballManager.onBallCountChanged -= UnsubscribeBallEscapeCounter;
    }
    private BallBounceGame CalculateGameStatistics()
    {
        BallBounceGame ballBounceGame = new BallBounceGame();
        ballBounceGame.howManyBallsFromVictory = AmountOfBallsToWIn - GameManager.instance.ballManager.BallCount;
        ballBounceGame.timeBeforeFirstBallEscaped = timeBeforeFirstBallEscaped;
        ballBounceGame.timeRemainingWhenGameFinished = startingAmountOfTime - (int)timePassedSinceGameStarted;

        Debug.Log(ballBounceGame.howManyBallsFromVictory);
        Debug.Log(ballBounceGame.timeBeforeFirstBallEscaped);
        Debug.Log(ballBounceGame.timeRemainingWhenGameFinished);

        return ballBounceGame;
    }

    
}
