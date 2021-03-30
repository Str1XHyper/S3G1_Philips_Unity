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

        SetupTileList();
    }
    #endregion

    private List<SmartTile> tiles = new List<SmartTile>();

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
}
