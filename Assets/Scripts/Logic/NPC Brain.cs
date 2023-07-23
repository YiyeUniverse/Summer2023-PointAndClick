using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBrain : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject NPCDestination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCDestination != null)
        {
        agent.SetDestination(NPCDestination.transform.position);
        }
    }
}
