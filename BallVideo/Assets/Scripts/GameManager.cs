using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameMode gameModeSettings;


    public BallManager ballManager;
    public ProgressManager progressManager;
    public CollisionManager collisionManager;

    public event Action onBallEscaped;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        progressManager.passOnGameData += gameModeSettings.isValidGame;
    }

    public void CallOnBallEscaped()
    {
        onBallEscaped?.Invoke();
        Debug.Log("OnBallEscaped called");
    }
}
