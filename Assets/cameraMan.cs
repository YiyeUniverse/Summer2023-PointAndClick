using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraMan : MonoBehaviour
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    //private CinemachineVirtualCamera ActiveCamera = null;
    public CinemachineVirtualCamera walkingCamera;
    public CinemachineVirtualCamera convoCamera;


    //Switch to standard camera
    public void setWalkingCamera()
    {
        convoCamera.Priority = 0;
        walkingCamera.Priority = 1;
    }
    
    //Switch to conversation camera
    public void setConvoCamera()
    {
        walkingCamera.Priority = 0;
        convoCamera.Priority = 1;
    }
}
