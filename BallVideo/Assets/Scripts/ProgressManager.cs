using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int amountOfBallsToWin;
    private int amountOfTimeInSeconds;
    [SerializeField]
    private float timeBetweenDecrement = 1;

    private int startingAmountOfTime;
    private float timePassedSinceGameStarted;

    private bool hasFirstBallEscaped = false;
    private float timeBeforeFirstBallEscaped;


    private bool isGameOver;

    public int AmountOfTimeInSeconds {  get { return amountOfTimeInSeconds; } }
    public int AmountOfBallsToWIn {  get { return amountOfBallsToWin; } }
    public float TimeBeforeFirstBallEscaped { get { return timeBeforeFirstBallEscaped;  } }
    public float TimePassedSinceGameStarted {  get { return timePassedSinceGameStarted; } }

    public event Action<float> onProgressUpdated;
    public event Action<int> onTimeRemainingUpdated;
    public event Action<bool> onGameComplete;
    public event Action passOnGameData;

    private void Start()
    {
        GameManager.instance.ballManager.onBallCountChanged += CalculateProgress;
        GameManager.instance.ballManager.onBallCountChanged += UnsubscribeBallEscapeCounter;

        amountOfBallsToWin = GameManager.instance.gameModeSettings.amountOfBallsToWin;
        amountOfTimeInSeconds = GameManager.instance.gameModeSettings.amountOfTimeInSeconds;

        startingAmountOfTime = amountOfTimeInSeconds;

        onTimeRemainingUpdated += CheckGameOver;
        onTimeRemainingUpdated?.Invoke(amountOfTimeInSeconds);
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

        //Bad work around as the win triggers one ball before at the moment
        if (progressPercentage > 100)
        {
            if (!isGameOver)
            {
                isGameOver = true;
                onGameComplete?.Invoke(true);
                passOnGameData?.Invoke();
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
                passOnGameData?.Invoke();
                CalculateGameStatistics();
            }
        }
    }

    private void UnsubscribeBallEscapeCounter(int ballCount)
    {
        hasFirstBallEscaped = true;
        GameManager.instance.ballManager.onBallCountChanged -= UnsubscribeBallEscapeCounter;
    }
    private void CalculateGameStatistics()
    {
        BallBounceGame ballBounceGame = new BallBounceGame();
        ballBounceGame.howManyBallsFromVictory = AmountOfBallsToWIn - GameManager.instance.ballManager.BallCount;
        ballBounceGame.timeBeforeFirstBallEscaped = timeBeforeFirstBallEscaped;
        ballBounceGame.timeRemainingWhenGameFinished = startingAmountOfTime - (int)timePassedSinceGameStarted;

        Debug.Log(ballBounceGame.howManyBallsFromVictory);
        Debug.Log(ballBounceGame.timeBeforeFirstBallEscaped);
        Debug.Log(ballBounceGame.timeRemainingWhenGameFinished);

        //passOnGameData?.Invoke(ballBounceGame);
    }

    
}
