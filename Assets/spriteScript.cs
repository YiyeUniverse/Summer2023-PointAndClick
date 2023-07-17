using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteScript : MonoBehaviour
{
    [SerializeField] GameObject spriteParent;
    //public bool rotatesWithParent = false;

    
    // Start is called before the first frame update
    void Start()
    {
        spriteParent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler (0.0f, 0.0f, spriteParent.transform.rotation.z * -1.0f);
    }
}
