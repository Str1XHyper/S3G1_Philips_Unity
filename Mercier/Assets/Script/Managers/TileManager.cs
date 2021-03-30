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
}
