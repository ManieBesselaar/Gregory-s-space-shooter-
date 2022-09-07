
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CinemachineVirtualCamera[] _virtualCameras;
    // Start is called before the first frame update
   enum VirtualCameras
    {
        CockpitCamera,
        FollowingCamera
    }

   
    int cameraIndex = 0;
    private void Start()
    {
        _virtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();
       }
    void CycleCameras()
    {
        _virtualCameras[cameraIndex].Priority = 10;
        cameraIndex++;
        if(cameraIndex >= _virtualCameras.Length) cameraIndex = 0;
        _virtualCameras[cameraIndex].Priority =11;
    
        }

    private void Update()
    {
        
      if(Input.GetKeyUp(KeyCode.C))
        {
            CycleCameras();
        };
    }
}
