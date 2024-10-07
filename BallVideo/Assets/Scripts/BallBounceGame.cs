using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceGame : MonoBehaviour
{
    public int howManyBallsFromVictory;
    public float timeBeforeFirstBallEscaped;
    public int timeRemainingWhenGameFinished;

    public int howManyBallsFromVictoryThreshold = 10;
    public float timeBeforeFirstBallEscapedThreshold = 4;
    public int timeRemainingWhenGameFinishedThreshold = 3;
}
