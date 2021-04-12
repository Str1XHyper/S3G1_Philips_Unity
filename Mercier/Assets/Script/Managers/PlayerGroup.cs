using System;
using UnityEngine;

public class PlayerGroup : MonoBehaviour
{
    [SerializeField]private Pawn groupPawn;
    [SerializeField]private Transform cam;

    private int currentMoneyAmount = 1;

    /// <summary>
    /// Subtract money from the playergroup amount
    /// </summary>
    /// <param name="tax"></param>
    /// <returns>Amount that was subtracted</returns>
    public int SubtractMoney(int tax)
    {
        if (currentMoneyAmount > tax)
        {
            currentMoneyAmount -= tax;
            return tax;
        }
        else if (currentMoneyAmount > 0)
        {
            int toReturn = currentMoneyAmount;
            currentMoneyAmount = 0;
            return toReturn;
        }
        else
        {
            currentMoneyAmount = 0;
            return currentMoneyAmount;
        }
    }

    public void GiveMoney(int moneysToGain)
    {
        currentMoneyAmount += moneysToGain;
    }

    public Pawn GroupPawn { get => groupPawn; private set => groupPawn = value; }
    public Transform Cam { get => cam; set => cam = value; }
    public int CurrentMoneyAmount { get => currentMoneyAmount; private set => currentMoneyAmount = value; }
}