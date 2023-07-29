using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerInteraction : MonoBehaviour
{
    NavMeshAgent agent;
    [Header ("Important Objects")]
    public GameObject stateDrivenCamera;
    public GameObject CameraFocus;

    [Header ("Debug Objects")]
    public GameObject textPanel;


    private GameObject otherParty;
    private float distanceToOtherParty;
    private float halfDistance;
    private bool isInteracting = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateDrivenCamera.GetComponent<CinemachineSwitcher>().mediumTrackingCamera(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting = false)
        {
            CameraFocus.transform.position = transform.position;
        }
    }

    
            //OnTalkTrigger
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "InteractionZone") 
        {
            isInteracting = true;
            Debug.Log("ConvoCamera");
            otherParty = other.gameObject.transform.parent.gameObject;
            distanceToOtherParty = otherParty.GetComponent<interactionLogic>().radius;
            halfDistance = distanceToOtherParty/2;

            //CameraFocus
            if (transform.position.x <= otherParty.transform.position.x)
            {
                CameraFocus.transform.position = new Vector3(otherParty.transform.position.x - halfDistance, otherParty.transform.position.y, otherParty.transform.position.z);
            } else
            {
                CameraFocus.transform.position = new Vector3(otherParty.transform.position.x + halfDistance, otherParty.transform.position.y, otherParty.transform.position.z);
            }
            stateDrivenCamera.GetComponent<CinemachineSwitcher>().conversationCamera();

            //Show Text panel
                Invoke("callNPCDialogue", 1.6f);
        }
    }

    void callNPCDialogue()
    {
        otherParty.GetComponent<interactionLogic>().DialogueLogic();
    }
    //Exit Interaction
    public void exitInteraction()
    {
        GetComponent<playerMovement>().ReactivatePlayer();
    }
}
