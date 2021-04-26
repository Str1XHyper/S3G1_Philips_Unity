using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StarPlacer : MonoBehaviour
{
    #region SingleTon
    public static StarPlacer instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    public void PlaceStarOnBoard()
    {
        RemoveCurrentStarFromBoard();
        PlaceNewStarOnTile();
    }

    private void RemoveCurrentStarFromBoard()
    {
        foreach (SmartTile tile in TileManager.instance.Tiles)
        {
            if (tile.StarOnTile)
            {
                tile.StarOnTile = false;
                tile.Star.DeSpawnStar();
                break;
            }
        }
    }

    private void PlaceNewStarOnTile()
    {
        SmartTile tileToPlaceStarOn = TileManager.instance.Tiles[UnityEngine.Random.Range(0, TileManager.instance.Tiles.Count)];

        if (tileToPlaceStarOn.GetType() == typeof(ChooseDirectionTile) || tileToPlaceStarOn.GetType() == typeof(PortalTile) || tileToPlaceStarOn.GetType() == typeof(BankTile) || tileToPlaceStarOn.GetType() == typeof(StartTile))
        {
            tileToPlaceStarOn = tileToPlaceStarOn.NextTile;
        }

        tileToPlaceStarOn.StarOnTile = true;
        tileToPlaceStarOn.Star.SpawnStar();
    }

}
