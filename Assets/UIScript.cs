using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        changePointerStyle();
    }

    // Update is called once per frame
    void Update()
    {
        pointer.transform.position = (Input.mousePosition);
    }

    void changePointerStyle()
    {
        return;
    }
}
