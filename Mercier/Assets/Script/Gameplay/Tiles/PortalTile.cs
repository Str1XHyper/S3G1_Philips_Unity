using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTile : SmartTile
{
    [SerializeField] private SmartTile alternateNextTile;

    public override void HandleTile(PlayerGroup currentPlayerGroup)
    {
        base.HandleTile(currentPlayerGroup);

        MoveToNextTile = false;
    }

    public SmartTile AlternateNextTile { get => alternateNextTile; private set => alternateNextTile = value; }
}
