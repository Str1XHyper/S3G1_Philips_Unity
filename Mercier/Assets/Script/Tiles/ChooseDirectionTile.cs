using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDirectionTile : SmartTile
{
    [SerializeField] private SmartTile alternateNextTile;

    public override void HandleTile()
    {
        base.HandleTile();
    }
}
