using UnityEngine;

[CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObjects/GameMode")]
public abstract class GameMode: ScriptableObject
{
    public int amountOfTimeInSeconds;
    public int newAmountToSpawn;
    public int amountOfBallsToWin;
    public GameObject objectToSpawn;
    public Color[] coloursToUse;
    public Color sliderFillColor;
    public Color winColor;
    public Color loseColor;
    public string firstLineText;
    public string secondLineText;
    public string thirdLineText;
    public string winningText;
    public string losingText;


    public abstract void isValidGame();

}
