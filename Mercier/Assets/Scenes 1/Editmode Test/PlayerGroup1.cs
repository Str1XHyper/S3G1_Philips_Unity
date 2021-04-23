using System;
using UnityEngine;

public class PlayerGroup : MonoBehaviour
{
    //[SerializeField]private Pawn groupPawn;
    [SerializeField]private Transform cam;

    private int currentAmountMoney = 0;
    private int currentAmountOfStars = 0;

    /// <summary>
    /// Subtract money from the playergroup amount
    /// </summary>
    /// <param name="tax"></param>
    /// <returns>Amount that was subtracted</returns>
    public int SubtractMoney(int tax)
    {
        if (currentAmountMoney > tax)
        {
            currentAmountMoney -= tax;
            return tax;
        }
        else if (currentAmountMoney > 0)
        {
            int toReturn = currentAmountMoney;
            currentAmountMoney = 0;
            return toReturn;
        }
        else
        {
            currentAmountMoney = 0;
            return currentAmountMoney;
        }
    }

    public void GiveMoney(int moneysToGain)
    {
        if(moneysToGain > 0)
        {
            currentAmountMoney += moneysToGain;
        }
    }

    public void GainStar(int amountOfGainedStars)
    {
        currentAmountOfStars += amountOfGainedStars;
    }

    public int CurrentMoneyAmount { get => currentAmountMoney; private set => currentAmountMoney = value; }
    public int CurrentAmountOfStars { get => currentAmountOfStars; private set => currentAmountOfStars = value; }
    //public Pawn GroupPawn { get => groupPawn; private set => groupPawn = value; }
    public Transform Cam { get => cam; set => cam = value; }
}