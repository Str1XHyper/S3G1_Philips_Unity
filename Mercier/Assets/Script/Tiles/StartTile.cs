using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTile : SmartTile
{
    private const int MoneyGainWhenPassingStart = 2;

    public override void HandleTile(PlayerGroup currentPlayerGroup)
    {
        base.HandleTile(currentPlayerGroup);
    }

    public override void HandlePassingTile(PlayerGroup currentPlayerGroup)
    {
        base.HandlePassingTile(currentPlayerGroup);

        currentPlayerGroup.GiveMoney(MoneyGainWhenPassingStart);

        Debug.Log("You passed start and gained " + MoneyGainWhenPassingStart + " money. New balance is " + currentPlayerGroup.CurrentMoneyAmount);
    }
}
