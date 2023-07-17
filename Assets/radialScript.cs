using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class radialScript : MonoBehaviour
{
    [Header ("Major Public GameObjects")]
    public GameObject RadialButtons;
    public GameObject RadialText;
    public GameObject interactionTarget;
    public GameObject player;

    [Header ("Prefabs")]
    public GameObject LookButton;
    public GameObject TalkButton;
    public GameObject AttackButton;

    [Header ("Animation Preferences")]
    public float entryDuration = 0.5f;
    public LeanTweenType entryEaseType;
    public float exitDuration = 0.2f;
    public LeanTweenType exitEaseType;

    
    //Buttons themselves
    [Header ("Current Radial Buttons (Debug)")]
    public List<GameObject> buttonList;
    public GameObject look;
    public GameObject talk;
    public GameObject attack;


    private float testNum;
    private float elapsedTime;
    //private float desiredDuration = 1f;
    private float thisArc;
    private RadialLayoutGroup buttonScript;
    private AudioSource audioData;

    //private float minimum = 0f;
    //private float maximum = 360f;

    // Start is called before the first frame update
    void Start()
    {   
        List<GameObject> buttonList = new List<GameObject>();
        audioData = GetComponent<AudioSource>();
    }

    
    //show Radial
    public void showRadial()
    {        
        gameObject.transform.localScale = new Vector3(1,1,1);
        RadialButtons.GetComponent<RadialLayoutGroup>().Arc = 360f;
        if (interactionTarget != null)
        {
            //Update text
            RadialText.GetComponent<TextMeshProUGUI>().text = interactionTarget.GetComponent<interactionLogic>().displayName; 
            RadialText.transform.localScale = new Vector3(0,0,0);
            LeanTween.scale(RadialText.GetComponent<RectTransform>(), new Vector3(1,1,1), entryDuration).setEase(entryEaseType);
            
            //Add Buttons
            if (buttonList != null){buttonList.Clear();}
            removeButtons();
            addButtons();     
        }
    }

    //Remove Buttons from Menu
    void removeButtons()
    {
        foreach(Transform child in RadialButtons.transform)
        {
            Destroy(child.gameObject);
        }
    }


    //Add Buttons to Menu
    void addButtons()
    {
        //Look
            if (interactionTarget.GetComponent<interactionLogic>().canLook == true)
            {
                look = Instantiate(LookButton, RadialButtons.transform);
                look.transform.SetParent(RadialButtons.transform);      
                Button lookBtn = look.GetComponent<Button>();
                lookBtn.onClick.AddListener(LookOnClick);     
                buttonList.Add(look);       
            }
            void LookOnClick()
            {
                interactionTarget.GetComponent<interactionLogic>().LookLogic();
                hideRadial();
            }
        //Talk
            if (interactionTarget.GetComponent<interactionLogic>().canTalk == true)
            {
                talk = Instantiate(TalkButton, RadialButtons.transform);
                talk.transform.SetParent(RadialButtons.transform);
                Button talkBtn = talk.GetComponent<Button>();
                talkBtn.onClick.AddListener(TalkOnClick);
                buttonList.Add(talk);
            }
            void TalkOnClick()
                {
                    interactionTarget.GetComponent<interactionLogic>().TalkLogic();
                    hideRadial();
                }
        //Attack
            if (interactionTarget.GetComponent<interactionLogic>().canAttack == true)
            {
                attack = Instantiate(AttackButton, RadialButtons.transform);
                attack.transform.SetParent(RadialButtons.transform);
                Button attackBtn = attack.GetComponent<Button>();
                attackBtn.onClick.AddListener(AttackOnClick);
                buttonList.Add(attack);
            }
            void AttackOnClick()
            {
                interactionTarget.GetComponent<interactionLogic>().AttackLogic();
                hideRadial();
            }

        //Animate Buttons' Entry
        animateRadialButtonsEntry();
    }

    //Animate Entry
    void animateRadialButtonsEntry()
    {
        foreach(GameObject buttonToAnimate in buttonList)
        {
                buttonToAnimate.transform.localScale = new Vector3(0,0,0);
                LeanTween.scale(buttonToAnimate.GetComponent<RectTransform>(), new Vector3(1,1,1), entryDuration).setEase(entryEaseType);
        }
    }

    //Animate Entry
    void animateRadialButtonsExit()
    {
                gameObject.transform.localScale = new Vector3(1,1,1);
                LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector3(0,0,0), exitDuration).setOnComplete(deactivateRadial).setEase(exitEaseType);
    }

    //Hide the Menu with animation
    public void hideRadial()
    {
        animateRadialButtonsExit();
        //gameObject.SetActive(false);
    }
    //Destroy the radial
     void deactivateRadial()
    {
        removeButtons();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
