using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour
{
    #region Singleton

    public static CameraMovementManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    public void MoveCameraToPos(Vector3 posToMoveTo)
    {

    }
}
