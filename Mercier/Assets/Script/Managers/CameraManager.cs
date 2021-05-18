using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private Camera camera;
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private float cameraSpeed;
    private Vector3 velocity = Vector3.zero;

    private bool transitioning = false;

    #region SingleTon
    public static CameraManager instance;

    private void Awake()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        cameraSpeed = cameraSpeed / 1000;
    }

    void Update()
    {
        if(transitioning)
        {
            MoveToPosition(cameraTarget.transform.position);
        }
        
    }

    private void MoveToPosition(Vector3 target)
    {
        if(Vector3.Distance(camera.transform.position, target) > 0.01f)
        {
            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, target, ref velocity, cameraSpeed);
            
        }
        else
        {
            camera.transform.SetParent(cameraTarget.transform);
            transitioning = false;
        }
    }

    public void ChangeCameraTarget(GameObject target)
    {
        camera.transform.parent = null;
        transitioning = true;
        cameraTarget = target;
    }

}
