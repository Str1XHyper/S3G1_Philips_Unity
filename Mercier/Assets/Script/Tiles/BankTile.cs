﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTile : SmartTile
{
    private const int Tax = 2;

    private int moneyInBank = 0;

    public override void HandleTile(PlayerGroup currentPlayerGroup)
    {
        base.HandleTile(currentPlayerGroup);
        GetMoneyFromBank(currentPlayerGroup);
    }

    public override void HandlePassingTile(PlayerGroup currentPlayerGroup)
    {
        base.HandlePassingTile(currentPlayerGroup);
        
        if (currentPlayerGroup.GroupPawn.MovedSpaces > 0)
        {
            GiveMoneyToBank(currentPlayerGroup);
        }

    }

    private void GetMoneyFromBank(PlayerGroup currentPlayerGroup)
    {
        currentPlayerGroup.GiveMoney(moneyInBank);
        Debug.Log("You received: " + moneyInBank);
        moneyInBank = 0;
        Debug.Log("New bank balance: " + moneyInBank);
    }

    private void GiveMoneyToBank(PlayerGroup currentPlayerGroup)
    {
        int subtractAmount = currentPlayerGroup.SubtractMoney(Tax);

        moneyInBank += subtractAmount;

        Debug.Log("Stuffed money in bank: " + subtractAmount);
        Debug.Log("New bank balance: " + moneyInBank);
    }
}
