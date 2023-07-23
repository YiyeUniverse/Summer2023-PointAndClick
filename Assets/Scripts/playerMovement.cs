using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    private Vector3 move;
    private CharacterController controller;

    [Header ("Basics")]
    public float playerSpeed = 4f;

    [Header ("The Boring Stuff")]
    public bool canControl = true;
    public bool canWalk = true;
    public bool canInteract = true;
    public GameObject marker;
    public GameObject radial;
    public interactionLogic interactionLogic;
    public Vector3 destination;

    [Header ("Camera Settings")]
    public GameObject stateDrivenCamera;
    public GameObject CameraFocus;

    [Header ("Interaction Settings")]
    public GameObject objectInteractedWith;

    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateDrivenCamera.GetComponent<CinemachineSwitcher>().mediumTrackingCamera();
        controller = gameObject.GetComponent<CharacterController>();
        agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Constantly check for hits
        RaycastHit hit;
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        
        
        //CheckMousePosition
        if (Input.GetMouseButton(1))
        {
            //Check if player can be controlled
            if (canControl == true && canWalk == true)
            {
                
                //MovePlayer
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    agent.SetDestination(hit.point);
                    marker.SetActive(true);  
                    marker.transform.position = hit.point;
                }
                

                Debug.Log("STAB!");
            }
        }


        //Interact
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    //Debug.Log( hit.transform.gameObject.name );


                    //Open radial Menu if InteractableObject
                    if((hit.transform.gameObject.GetComponent("interactionLogic") as interactionLogic) != null && canInteract == true)
                    {
                        radial.GetComponent<radialScript>().interactionTarget = hit.transform.gameObject;
                        OpenRadialMenu();
                        canControl=false;
                        canInteract = false;
                        agent.enabled = true;
                        
                    }
                }
            
        }
    }


    // Open Radial Menu
    void OpenRadialMenu()
        {
            radial.SetActive(true);
            radial.transform.position = (Input.mousePosition);
            radial.GetComponent<radialScript>().showRadial();  
            marker.SetActive(false); 
            canWalk = false;
        }

    //Reactivate Player after Closing Menu    
    public void ReactivatePlayer()
    {
        objectInteractedWith = null;
        stateDrivenCamera.GetComponent<CinemachineSwitcher>().mediumTrackingCamera();
        canControl = true;
        canInteract = true;
        canWalk = true;
        agent.enabled = true;
        destination = new Vector3(0,0,0);
    }

    //Walk towards Interactable
    public void walkToDestination()
    {
        //CameraFocus.transform.position.x = 2;
        agent.enabled = true;
        agent.SetDestination(destination);    
        return;
    }


}
