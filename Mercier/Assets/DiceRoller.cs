using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    #region SingleTon
    public static DiceRoller instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    private const int DiceMin = 1;
    private const int DiceMax = 6;

    private int randomNumber = 1;

    public int GetRandomNumber()
    {
        RollDice();
        return randomNumber;
    }

    private void RollDice()
    {
        randomNumber = Random.Range(DiceMin, DiceMax);
        Debug.Log("You rolled: " + randomNumber);
    }
}
