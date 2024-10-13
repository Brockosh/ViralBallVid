using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private GameObject referenceObject;
    private int newSpawnAmount = 2;
    private Color[] colourOptions;

    private int ballCount = 0;
    public event Action<int> onBallCountChanged;
    public float radius = 1f;
    public bool first = true;

    public int BallCount {  get { return ballCount; } }

    private void Start()
    {
        GameManager.instance.onBallEscaped += SpawnBall;
        GameManager.instance.onBallEscaped += DecrementBallCount;

        referenceObject = GameManager.instance.gameModeSettings.objectToSpawn;
        newSpawnAmount = GameManager.instance.gameModeSettings.newAmountToSpawn;
        colourOptions = GameManager.instance.gameModeSettings.coloursToUse;
        SpawnBall();
    }

    private void SpawnBall()
    {
        if (first)
        {
            newSpawnAmount = 1;
            first = false;
        }
        else
        {
            newSpawnAmount = GameManager.instance.gameModeSettings.newAmountToSpawn;
        }

        for (int i = 0; i < newSpawnAmount; i++)
        {
            GameObject newBall = Instantiate(referenceObject, GetRandomPosition(), Quaternion.identity);
            newBall.GetComponent<SpriteRenderer>().color = colourOptions[UnityEngine.Random.Range(0, colourOptions.Length)];
            ballCount++;
            onBallCountChanged?.Invoke(ballCount);
        }
    }

    private void DecrementBallCount()
    {
        ballCount--;
        onBallCountChanged?.Invoke(ballCount);
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 randomPositionVector = new Vector2(UnityEngine.Random.Range(-1f, 1.0f), UnityEngine.Random.Range(-1f, 1.0f));
        randomPositionVector *= radius;

        return randomPositionVector;
    }
}