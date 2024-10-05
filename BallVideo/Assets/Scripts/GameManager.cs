using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action onBallEscaped;

    public BallManager ballManager;

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
