using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject pointer;
    public GameObject talkWindow;
    public GameObject talkText;

    private TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        changePointerStyle();
        pointer.SetActive(false);

        //Dialogue Window
        dialogueText = talkText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pointer.transform.position = (Input.mousePosition);
    }

    

    //Change Pointer
    void changePointerStyle()
    {
        return;
    }



}
