using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase componentBase;
     float cameraDistance;
    [SerializeField] float sensitivity = 20f;
    [SerializeField] float maxCameraCloseness = 7f;
    [SerializeField] float maxCameraDistance = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (componentBase == null)
       {
        componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
       }

       if (Input.GetAxis("Mouse ScrollWheel") != 0 )
       {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            if (componentBase is CinemachineFramingTransposer)
            {
                if (cameraDistance < 0)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                    if ((componentBase as CinemachineFramingTransposer).m_CameraDistance > maxCameraDistance)
                    {
                        (componentBase as CinemachineFramingTransposer).m_CameraDistance = maxCameraDistance;
                    }
                }
                else
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                    if ((componentBase as CinemachineFramingTransposer).m_CameraDistance < maxCameraCloseness)
                    {
                        (componentBase as CinemachineFramingTransposer).m_CameraDistance = maxCameraCloseness;
                    }
                }
            }
       }
    }
}
