using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject referenceObject;
    [SerializeField] private int newSpawnAmount = 2;
    [SerializeField] private Color[] colourOptions;

    private int ballCount = 0;
    public event Action<int> onBallCountChanged;
    public float radius = 1f;


    private void Start()
    {
        GameManager.instance.onBallEscaped += SpawnBall;
        GameManager.instance.onBallEscaped += DecrementBallCount;
        SpawnBall();
    }

    private void SpawnBall()
    {
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