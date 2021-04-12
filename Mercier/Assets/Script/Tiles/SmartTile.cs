using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartTile : MonoBehaviour
{
    [SerializeField] private Material tileColor;
    [SerializeField] private SmartTile nextTile;
    [SerializeField] private Transform pawnPos;

    private bool moveToNextTile = true;
    private bool starOnTile;

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
            //Handle star on tile

        }
    }

    public bool StarOnTile { get => starOnTile; set => starOnTile = value; }
    public Material TileColor { get => tileColor; private set => tileColor = value; }
    public SmartTile NextTile { get => nextTile; private set => nextTile = value; }
    public Vector3 PawnPos { get => pawnPos.position; private set => pawnPos.position = value; }
    public bool OnPassingTriggerTile { get; internal set; }
    public bool MoveToNextTile { get => moveToNextTile; set => moveToNextTile = value; }
}
