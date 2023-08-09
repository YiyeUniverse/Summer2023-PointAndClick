using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spriteFlipper : MonoBehaviour
{
    public GameObject spriteHolder;
    public GameObject sprite;
    private NavMeshAgent agent;

    private Vector3 lookRight;
    private Vector3 lookLeft;
    

    // Start is called before the first frame update
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        spriteHolder.transform.rotation = Quaternion.Euler (0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);

        if (agent.destination.x >= gameObject.transform.position.x)
        {
            sprite.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            sprite.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }


    }
}
