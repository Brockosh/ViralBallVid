using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameAnalyser
{
    private static bool DetermineIfPostable(BallBounceGame gameToAnalyse)
    {
        if 
        (
            gameToAnalyse.timeBeforeFirstBallEscaped < gameToAnalyse.timeBeforeFirstBallEscapedThreshold &&
            gameToAnalyse.timeRemainingWhenGameFinished < gameToAnalyse.timeRemainingWhenGameFinishedThreshold &&
            gameToAnalyse.howManyBallsFromVictory < gameToAnalyse.howManyBallsFromVictoryThreshold)
        {
            return true;
        }
        return false;
    }
}
