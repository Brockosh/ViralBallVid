using UnityEngine;

[CreateAssetMenu(fileName = "GameModeSettings", menuName = "ScriptableObjects/GameModeSettings")]
public class GameModeSettings : ScriptableObject
{
    public int amountOfBallsToWin;
    public int amountOfTimeInSeconds;
    public GameObject objectToSpawn;
    public int newAmountToSpawn;
    public Color[] coloursToUse;
    public Color winColor;
    public Color loseColor;
}
