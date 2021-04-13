using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaymentTile : SmartTile
{
    private const int PayUpAmount = 3;

    public override void HandleTile(PlayerGroup currentPlayerGroup)
    {
        base.HandleTile(currentPlayerGroup);

        int payedAmount = currentPlayerGroup.SubtractMoney(PayUpAmount);
        Debug.Log("You lost " + payedAmount + " money");
        Debug.Log("New balance is " + currentPlayerGroup.CurrentMoneyAmount + " money");
        UI_manager.instance.UpdateText();
    }
}
