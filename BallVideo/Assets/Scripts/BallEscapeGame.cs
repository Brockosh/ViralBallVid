using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/BallEscapeGame")]
public class BallEscapeGame : GameMode
{
    private void OnEnable()
    {
        firstLineText = $"Target: {amountOfBallsToWin}";
    }
    public override void isValidGame()
    {

        BallBounceGame ballBounceGame = new BallBounceGame();
        ballBounceGame.howManyBallsFromVictory = GameManager.instance.gameModeSettings.amountOfBallsToWin - GameManager.instance.ballManager.BallCount;
        ballBounceGame.timeBeforeFirstBallEscaped = GameManager.instance.progressManager.TimeBeforeFirstBallEscaped;
        ballBounceGame.timeRemainingWhenGameFinished = GameManager.instance.gameModeSettings.amountOfTimeInSeconds - (int)GameManager.instance.progressManager.TimePassedSinceGameStarted;

        Debug.Log("GAME STATS");
        Debug.Log($"Balls from victory: {ballBounceGame.howManyBallsFromVictory}");
        Debug.Log($"Time before first ball escaped: {ballBounceGame.timeBeforeFirstBallEscaped}");
        Debug.Log($"Time remaining when game finished:{ballBounceGame.timeRemainingWhenGameFinished}");


        if (ballBounceGame.timeBeforeFirstBallEscaped > 5)
        {
            Debug.Log("Returning false due to 1st");
            ReturnResults(false);

        }
        else if (ballBounceGame.timeRemainingWhenGameFinished > 5)
        {
            Debug.Log("Returning false due to 2nd");
            ReturnResults(false);

        }
        else if (ballBounceGame.howManyBallsFromVictory > 5)
        {
            Debug.Log("Returning false due to 3rd");
            ReturnResults(false);
        }
        else
        {
            Debug.Log("Returning true");
            ReturnResults(true);
        }

    }

    public bool ReturnResults(bool result)
    {
        return result;
    }

  
}
