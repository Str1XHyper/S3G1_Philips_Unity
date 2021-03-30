﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartTile : MonoBehaviour
{
    [SerializeField] private Material tileColor;
    [SerializeField] private SmartTile nextTile;
    [SerializeField] private 

    private bool starOnTile;

    public void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (TileColor != null)
        {
            renderer.material = TileColor;
        }
    }

    public virtual void HandleTile()
    {

    }

    private void OnDrawGizmos()
    {
        MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();

        if (TileColor != null)
        {
            renderer.material = TileColor;
        }
    }

    public bool StarOnTile { get => starOnTile; set => starOnTile = value; }
    public Material TileColor { get => tileColor; private set => tileColor = value; }
    public SmartTile NextTile { get => nextTile; private set => nextTile = value; }
}
