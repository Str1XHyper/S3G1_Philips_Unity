using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartTile : MonoBehaviour
{
    private const int StarCost = 5;
    private const int DefaultAmountOfStarsToGain = 1;

    [SerializeField] private Material tileColor;
    [SerializeField] private SmartTile nextTile;
    [SerializeField] private Transform pawnPos;
    [SerializeField] private Star star;

    private bool moveToNextTile = true;
    private bool starOnTile = false;

    private SpaceType tileType;

    private void Awake()
    {
        star = GetComponentInChildren<Star>();
        star.DeSpawnStar();
    }

    public void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (TileColor != null)
        {
            renderer.material = TileColor;
        }
    }

    public virtual void HandleTile(PlayerGroup currentPlayerGroup)
    {

    }

    public virtual void HandlePassingTile(PlayerGroup currentPlayerGroup)
    {
        if (starOnTile)
        {
            if (currentPlayerGroup.CurrentMoneyAmount >= StarCost)
            {
                int payedAmount = currentPlayerGroup.SubtractMoney(StarCost);
                currentPlayerGroup.GainStar(DefaultAmountOfStarsToGain);

                Debug.Log("You bought a star for " + payedAmount + ".");
                Debug.Log("New balance is " + currentPlayerGroup.CurrentMoneyAmount);

                SocketCaller.instance.BoughtStar(new BoughtStar(currentPlayerGroup.GroupPawn.PlayerID));

                UI_manager.instance.UpdateText();

                StarPlacer.instance.PlaceStarOnBoard();
            }
        }
    }

    public bool StarOnTile { get => starOnTile; set => starOnTile = value; }
    public Material TileColor { get => tileColor; private set => tileColor = value; }
    public SmartTile NextTile { get => nextTile; private set => nextTile = value; }
    public Vector3 PawnPos { get => pawnPos.position; private set => pawnPos.position = value; }
    public bool OnPassingTriggerTile { get; internal set; }
    public bool MoveToNextTile { get => moveToNextTile; set => moveToNextTile = value; }
    public Star Star { get => star; private set => star = value; }

    public SpaceType TileType { get => tileType; set => tileType = value; }
}
