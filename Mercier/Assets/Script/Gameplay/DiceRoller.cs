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

    [SerializeField] private Animator diceAnimator;

    private const int DiceMin = 1;
    private const int DiceMax = 6;

    private int randomNumber = 1;

    public int GetRandomNumber()
    {
        RollDice();
        UpdateUI();
        return randomNumber;
    }

    public void StartRollAnimation()
    {
        diceAnimator.SetInteger(0, 0);
    }

    private void RollDice()
    {
        randomNumber = Random.Range(DiceMin, DiceMax);
    }

    private void UpdateUI()
    {
        diceAnimator.SetInteger(0, randomNumber);
        UI_manager.instance.UpdateText();
    }
}
