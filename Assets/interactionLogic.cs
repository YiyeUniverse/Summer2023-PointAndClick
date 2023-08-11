using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionLogic : MonoBehaviour
{
    private GameObject gameManagerObj;
    private GameObject playerObject;
    private NPCDialogue NPCDialogue;
    private GameObject canvas;

    public enum InteractionMode { Character, Pickup };

    [Header ("Basic Settings")]
    public string displayName;

    [Header("Interactions")]
    public bool canHover = true;
    public bool canLook = false;
    public bool canTalk = false;
    public bool canAttack = false;
    public bool canThrowAt = false;
    public bool canPickUp = false;
    public bool canOtherInteraction = false;
    public string defaultBehaviourType;

    [Header("Objects")]
    public GameObject InteractionZone;
    public GameObject dialogueManagerObj;
    public float radius = 2f;

    [Header("Text")]
    public string dialogueKnot;
    public string lookKnot;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        gameManagerObj.GetComponent<GameManager>();
        NPCDialogue = gameObject.GetComponent<NPCDialogue>();
        dialogueManagerObj = GameObject.Find("DialogueManager");
        canvas = GameObject.Find("Canvas");

        playerObject = GameObject.Find("Player");
        GameObject leftWaypoint = new GameObject();
        leftWaypoint.transform.SetParent(gameObject.transform);
        GameObject rightWaypoint = new GameObject();
        rightWaypoint.transform.SetParent(gameObject.transform);
    }


    //Update loop
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        //Choose Behaviour Type
        if (canTalk == true)
        {
            defaultBehaviourType = "Talk";
            canvas.GetComponent<UIScript>().pointerTextText = "Talk";
        } else if (canLook == true)
        {
            defaultBehaviourType = "Look";
            canvas.GetComponent<UIScript>().pointerTextText = "Examine";
        }
        //Check distance to player and show text
        if (playerObject.GetComponent<playerMovement>().canInteract == true)
        {
            canvas.GetComponent<UIScript>().showPointerText();
        }
    }

    void OnMouseExit()
    {
        canvas.GetComponent<UIScript>().hidePointerText();
    }

    void OnMouseDown()
    {
        if (playerObject.GetComponent<playerMovement>().canInteract == true && canvas.GetComponent<UIScript>().radialActive == false)
        {
            playerObject.GetComponent<playerMovement>().DeactivatePlayer();
            defaultBehaviour();
        }
    }

    public void defaultBehaviour()
    {
        canvas.GetComponent<UIScript>().hidePointerText();
        if (defaultBehaviourType == "Talk")
        {
            TalkLogic();
        }

        if (defaultBehaviourType == "Look")
        {
            LookLogic();
        }
    }
    //Logics
        //Looking
        public void LookLogic()
        {
            Debug.Log("I am looking at " + displayName);
            //playerObject.GetComponent<playerMovement>().ReactivatePlayer();
            if (lookKnot == null){lookKnot = "LookKnot";}
            dialogueManagerObj.GetComponent<inkExample>().currentKnot = this.lookKnot;
            dialogueManagerObj.GetComponent<inkExample>().StartStory();
            dialogueManagerObj.GetComponent<inkExample>().showDialogueGUI();
            playerObject.GetComponent<playerMovement>().DeactivatePlayer();
            canvas.GetComponent<UIScript>().hidePointerText();
            
        }

        //Sort interaction zones for talking
        public void TalkLogic()
        {
            Debug.Log("Initiating conversation with " + displayName);
            InteractionZone.SetActive(true);
            canvas.GetComponent<UIScript>().hidePointerText();
            if (playerObject.transform.position.x <= transform.position.x)
            {
                playerObject.GetComponent<playerMovement>().destination = new Vector3(gameObject.transform.position.x - radius, gameObject.transform.position.y, gameObject.transform.position.z);
                playerObject.GetComponent<playerMovement>().walkToDestination();
            }else
            {
                playerObject.GetComponent<playerMovement>().destination = new Vector3(gameObject.transform.position.x + radius, gameObject.transform.position.y, gameObject.transform.position.z);
                playerObject.GetComponent<playerMovement>().walkToDestination();
            }
        }

        //Sort Dialogue
        public void DialogueLogic()
        {
            if (dialogueKnot == null){dialogueKnot = "TalkKnot";}
            dialogueManagerObj.GetComponent<inkExample>().currentKnot = this.dialogueKnot;
            dialogueManagerObj.GetComponent<inkExample>().StartStory();
            dialogueManagerObj.GetComponent<inkExample>().showDialogueGUI();
            deactivateInteraction();
            canvas.GetComponent<UIScript>().hidePointerText();
        }

        //Deactivate Interaction Zones
        private void deactivateInteraction()
        {
            InteractionZone.SetActive(false);

        }
        //Looking
        public void AttackLogic()
        {
            Debug.Log("I am attacking " + displayName);
            playerObject.GetComponent<playerMovement>().ReactivatePlayer();
        }
}
