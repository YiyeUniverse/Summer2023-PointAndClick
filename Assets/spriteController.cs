using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteController : MonoBehaviour
{
    public GameObject sprite;
    private spriteScript spriteScript;
    private interactionLogic interactionLogic;
    private GameObject player;
    private playerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteScript = sprite.GetComponent<spriteScript>();
        interactionLogic = gameObject.GetComponent<interactionLogic>();
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<playerMovement>();
    }

    void OnMouseOver()
    {
        if (interactionLogic.canHover == true && playerMovement.canInteract == true)
        {
            showOutline();
        }
    }

    void OnMouseExit()
    {
        hideOutline();
    }

    //Show the Outline
    public void showOutline()
    {
        spriteScript.activeOutline = true;
    }

    //HidetheOutline
    public void hideOutline()
    {
        spriteScript.activeOutline = false;
    }
}
