using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    #region SingleTon
    public static TileManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }

    }
    #endregion

    private List<SmartTile> tiles = new List<SmartTile>();

    private void Start()
    {
        SetupTileList();
    }

    private void SetupTileList()
    {
        foreach (SmartTile tile in transform.GetComponentsInChildren<SmartTile>())
        {
            tiles.Add(tile);
        }
    }

    public SmartTile GetStartTile()
    {
        foreach (SmartTile tile in tiles)
        {
            if (typeof(StartTile) == tile.GetType())
            {
                return tile;
            }
        }

        return tiles[0];
    }


    public SmartTile CheckForAlternateDirectionPortalTile(SmartTile currentSmartTile, SmartTile tileToMoveTo)
    {
        if (currentSmartTile.GetType() == typeof(PortalTile))
        {
            if (!currentSmartTile.MoveToNextTile)
            {
                PortalTile portalTile = (PortalTile)currentSmartTile;
                tileToMoveTo = portalTile.AlternateNextTile;
                currentSmartTile.MoveToNextTile = true;
            }
        }

        return tileToMoveTo;
    }

    public SmartTile GetCorrectDirectionFromDirectionTile(SmartTile currentSmartTile, SmartTile tileToMoveTo)
    {
        if (currentSmartTile.GetType() == typeof(ChooseDirectionTile))
        {
            ChooseDirectionTile directionTile = (ChooseDirectionTile)currentSmartTile;

            if (currentSmartTile.MoveToNextTile)
            {
                tileToMoveTo = directionTile.AlternateNextTile;
            }
        }

        return tileToMoveTo;
    }


    public List<SmartTile> Tiles { get => tiles; set => tiles = value; }
}
