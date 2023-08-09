using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteScript : MonoBehaviour
{
    [SerializeField] GameObject spriteParent;
    [SerializeField] Material spriteMaterial;
    public bool activeOutline = false;
    [SerializeField] Color spriteColor;
    [SerializeField] Material material;
    [SerializeField] Material newMaterial;
    private GameObject go;
    private GameObject player;

    //public bool rotatesWithParent = false;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteParent = transform.parent.gameObject;

        go = this.gameObject;
        material = go.GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeOutline == true)
        {
            material.SetInt( "_OutlineActive", 1 );
        }
        if (activeOutline == false)
        {
            material.SetInt( "_OutlineActive", 0 );
        }
    }
}
