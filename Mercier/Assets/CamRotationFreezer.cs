using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotationFreezer : MonoBehaviour
{
    [SerializeField] private Transform child;

    private Quaternion iniRot;
    private Vector3 iniPos;

    private void Start()
    {
        iniRot = child.transform.rotation;
        iniPos = child.transform.localPosition;
    }

    private void LateUpdate()
    {
        child.transform.rotation = iniRot;
        child.transform.localPosition = iniPos;
    }
}
