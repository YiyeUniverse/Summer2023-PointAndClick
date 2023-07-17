using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionLogic : MonoBehaviour
{
    private GameObject gameManagerObj;
    private GameObject playerObject;

    public enum InteractionMode { Character, Pickup };

    [Header ("Basic Settings")]
    public string displayName;

    [Header("Interactions")]
    public bool canLook = false;
    public bool canTalk = false;
    public bool canAttack = false;
    public bool canThrowAt = false;
    public bool canPickUp = false;
    public bool canOtherInteraction = false;

    [Header("Objects")]
    public GameObject InteractionZone;
    public float radius = 2f;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        gameManagerObj.GetComponent<GameManager>();

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


    //Logics

        //Looking
        public void LookLogic()
        {
            Debug.Log("I am looking at " + displayName);
            playerObject.GetComponent<playerMovement>().ReactivatePlayer();
        }

        //Looking
        public void TalkLogic()
        {
            Debug.Log("Initiating conversation with " + displayName);
            InteractionZone.SetActive(true);
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

        //Looking
        public void AttackLogic()
        {
            Debug.Log("I am attacking " + displayName);
            playerObject.GetComponent<playerMovement>().ReactivatePlayer();
        }
}