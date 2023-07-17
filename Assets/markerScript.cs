using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerScript : MonoBehaviour
{
    public GameObject arrow;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
       //LeanTween.moveY(arrow, arrow.transform.position.y+distance, 1f).setLoopPingPong(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
