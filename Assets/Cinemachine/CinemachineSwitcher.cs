using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{

    public Animator animator;
    private bool trackingCamera = true;

    public GameObject player;
    public GameObject cameraFocus;
    
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void update()
    {
        cameraFocus.transform.position = player.transform.position;
    }


    public void mediumTrackingCamera()
    {
        animator.Play("TrackingMedium");
    }

    public void conversationCamera()
    {
        animator.Play("convoCamera");
    }
}
