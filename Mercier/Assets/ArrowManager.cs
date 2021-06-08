using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    #region SingleTon
    public static ArrowManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;

    public void HideAllArrows()
    {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }

    public void ShowArrows(MovementDirection defaultDirection, MovementDirection alternateDirection)
    {
        switch (defaultDirection)
        {
            case MovementDirection.LEFT:
                leftArrow.SetActive(true);
                break;
            case MovementDirection.RIGHT:
                rightArrow.SetActive(true);
                break;
            case MovementDirection.UP:
                upArrow.SetActive(true);
                break;
            case MovementDirection.DOWN:
                downArrow.SetActive(true);
                break;
        }

        switch (alternateDirection)
        {
            case MovementDirection.LEFT:
                leftArrow.SetActive(true);
                break;
            case MovementDirection.RIGHT:
                rightArrow.SetActive(true);
                break;
            case MovementDirection.UP:
                upArrow.SetActive(true);
                break;
            case MovementDirection.DOWN:
                downArrow.SetActive(true);
                break;
        }
    }
}