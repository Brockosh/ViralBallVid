using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameModeSettings gameModeSettings;


    public BallManager ballManager;
    public ProgressManager progressManager;
    public CollisionManager collisionManager;

    public event Action onBallEscaped;

    private void Awake()
    {
        instance = this;
    }

    public void CallOnBallEscaped()
    {
        onBallEscaped?.Invoke();
        Debug.Log("OnBallEscaped called");
    }
}
