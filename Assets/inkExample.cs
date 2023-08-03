using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;

public class inkExample : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;

    [Header ("Ink GameObjects")]
	[SerializeField]
	private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField]
	private Canvas canvas = null;
	[SerializeField]
	private GameObject dialoguePanel = null;

	// UI Prefabs
	[SerializeField]
	private GameObject dialogueTextObject = null;
	[SerializeField]
	private Button buttonPrefab = null;
    [SerializeField]
	private GameObject choicePanel = null;

    [SerializeField] private GameObject player;

	[Header ("Animation Settings")]
	[SerializeField] private float dialogueEntryDuration;
	[SerializeField] private LeanTweenType dialogueEntryEaseType;
	[SerializeField] private float choiceDelay = 1f;
	[SerializeField] private float choiceEntryDuration;
	[SerializeField] private LeanTweenType choiceEntryEaseType;

	[Header ("Other Stuff")]
	public string currentKnot = "StartKnot";
	public GameObject postProc;
	private  postprocessingController postProcessingController;




    private TextMeshProUGUI dialogueText;
	
    
    void Start()
    {
        dialogueText = dialogueTextObject.GetComponent<TextMeshProUGUI>();
		postProcessingController = postProc.GetComponent<postprocessingController>();
    }
    void Awake () {
		// Remove the default message
		RemoveChildren();
		//StartStory();
	}

	//GUI Things
		//Show Dialouge GUI
		public void showDialogueGUI()
		{
			choicePanel.SetActive(false);
			Invoke("displayDialoguePanel", 0.15f);
			postProcessingController.IntensifyVignette();
		}
			void displayDialoguePanel(){dialoguePanel.SetActive(true);}

		//Hide Dialouge GUI
		public void hideDialogueGUI()
		{
			dialoguePanel.SetActive(false);
			choicePanel.SetActive(false);
			postProcessingController.ResetVignette();
		}

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory () {
		story = new Story (inkJSONAsset.text);
        if(OnCreateStory != null) OnCreateStory(story);
		if (currentKnot == null) {currentKnot = "StartKnot";}
		story.ChoosePathString(currentKnot);
		RefreshView();
	}
	
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView () {
		// Remove all the UI on screen
		RemoveChildren ();

		choicePanel.SetActive(false);

		// Read all the content until we can't continue any more
		while (story.canContinue) {
			// Continue gets the next line of the story
			string text = story.Continue ();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		//Animate
			animateEntry();
		}

		// Display all the choices, if there are any!
		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished! END OF STORY
		else {
            player.GetComponent<playerMovement>().ReactivatePlayer();
			hideDialogueGUI();
			/*
            Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate{
				//StartStory();
                
			});
            */
		}
	}

	//Animate text
	void animateEntry()
	{
		//Text Entry
		dialogueTextObject.transform.localScale = new Vector3(1.25f,1.25f,1.25f);
        LeanTween.scale(dialogueTextObject.GetComponent<RectTransform>(), new Vector3(1,1,1), dialogueEntryDuration).setEase(dialogueEntryEaseType);

		//Choice entry
		choicePanel.SetActive(false);
		//Invoke("animateChoices", dialogueEntryDuration+choiceDelay);
	}
	
	// Trigger choice animation
	//public void triggerChoiceAnimation(){Invoke("animateChoices", 0.15f);}

	public void animateChoices()
	{
		choicePanel.SetActive(true);
		choicePanel.transform.localScale = new Vector3(1f,0f,0f);
		LeanTween.scale(choicePanel.GetComponent<RectTransform>(), new Vector3(1,1,1), choiceEntryDuration).setEase(choiceEntryEaseType);
	}
	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView (string text) {
		dialogueTextObject.GetComponent<TextMeshProUGUI>().text = text;
        //Debug.Log(text);
	}

	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (choicePanel.transform, false);
		
		// Gets the text from the button prefab
		choice.GetComponentInChildren<TextMeshProUGUI>().text = text;

		// Make the button expand to fit the text
		//HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		//layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = choicePanel.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (choicePanel.transform.GetChild (i).gameObject);
		}
	}
}
