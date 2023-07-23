using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
/*
    [Header ("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    private bool dialougeIsPlaying;

    private static DialougeManager instance;

    private void Start()
    {
        dialougeIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    //Emter dialogue mode
    public void EnterDialougeMode()
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialougeMode();
        }
    }

    //Exit dialogue Mode
    private void ExitDialougeMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.setActive(false);
        dialogueText.text = "";
    }

    //Traverse logic of ink story
    private void Update()
    {
        //only update when dialouge playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing

    }
    
    // Set instance on awake etc
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
*/
}
