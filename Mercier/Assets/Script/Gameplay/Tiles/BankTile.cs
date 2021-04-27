using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTile : SmartTile
{
    private const int Tax = 2;

    private int moneyInBank = 0;

    new private void Start()
    {
        base.Start();

        TileType = SpaceType.BANK;
    }

    public override void HandleTile(PlayerGroup currentPlayerGroup)
    {
        base.HandleTile(currentPlayerGroup);
        GetMoneyFromBank(currentPlayerGroup);
    }

    public override void HandlePassingTile(PlayerGroup currentPlayerGroup)
    {
        base.HandlePassingTile(currentPlayerGroup);
        
        if (currentPlayerGroup.GroupPawn.AmountAlreadyMoved > 0)
        {
            SocketCaller.instance.PassedBank(new PassedBankMessage(currentPlayerGroup.GroupPawn.PlayerID));
            GiveMoneyToBank(currentPlayerGroup);
        }

    }

    private void GetMoneyFromBank(PlayerGroup currentPlayerGroup)
    {
        currentPlayerGroup.GiveMoney(moneyInBank);
        Debug.Log("You received: " + moneyInBank);
        moneyInBank = 0;
        Debug.Log("New bank balance: " + moneyInBank);
        UI_manager.instance.UpdateText();
    }

    private void GiveMoneyToBank(PlayerGroup currentPlayerGroup)
    {
        int subtractAmount = currentPlayerGroup.SubtractMoney(Tax);

        moneyInBank += subtractAmount;

        Debug.Log("Stuffed money in bank: " + subtractAmount);
        Debug.Log("New bank balance: " + moneyInBank);
        UI_manager.instance.UpdateText();
    }
}
