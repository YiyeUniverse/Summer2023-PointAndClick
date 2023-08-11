using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject pointer;
    public GameObject pointerText;
    public string pointerTextText;
    public GameObject talkWindow;
    public GameObject talkText;
    public bool radialActive = false;

    private TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        changePointerStyle();
        pointer.SetActive(true);

        //Dialogue Window
        dialogueText = talkText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pointer.transform.position = (Input.mousePosition);

        //Hide pointer on click
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
        }
    }



    //Change Pointer
    void changePointerStyle()
    {
        return;
    }

    //Show and hide Pointer Text
    public void showPointerText()
    {
        pointerText.SetActive(true);
        pointerText.GetComponent<TextMeshProUGUI>().text = pointerTextText;
    }
    public void hidePointerText()
    {
        pointerText.SetActive(false);
    }

    //Deal with Radial
    public void radialisActive(){radialActive = true;}
    public void radialInactive(){radialActive = false;}


}
