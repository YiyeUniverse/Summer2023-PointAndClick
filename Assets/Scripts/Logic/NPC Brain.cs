using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBrain : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject NPCdestination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCdestination != null)
        {
        agent.SetDestination(NPCdestination.transform.position);
        }
    }
}
