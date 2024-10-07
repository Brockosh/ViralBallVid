using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameVerdict : MonoBehaviour
{
    private bool hasFirstBallEscaped = false;
    float timeBeforeFirstBallEscaped = 0f;



    private void Awake()
    {
        
    }

    private void Start()
    {
        GameManager.instance.ballManager.onBallCountChanged += StopFirstBallEscapedTimer;
    }

    private void Update()
    {
        if (!hasFirstBallEscaped)
            timeBeforeFirstBallEscaped += Time.deltaTime;
    }

    private void StopFirstBallEscapedTimer(int ballCount)
    {
        hasFirstBallEscaped = true;
        GameManager.instance.ballManager.onBallCountChanged -= StopFirstBallEscapedTimer;
    }


}
