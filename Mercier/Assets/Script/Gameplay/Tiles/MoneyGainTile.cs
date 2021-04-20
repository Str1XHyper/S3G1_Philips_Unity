using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGainTile : SmartTile
{
    private const int AmountToGain = 3;

    public override void HandleTile(PlayerGroup currentPlayerGroup)
    {
        base.HandleTile(currentPlayerGroup);

        currentPlayerGroup.GiveMoney(AmountToGain);

        Debug.Log("You gained " + AmountToGain + " money you new balance is " + currentPlayerGroup.CurrentMoneyAmount);
        UI_manager.instance.UpdateText();
    }
}
