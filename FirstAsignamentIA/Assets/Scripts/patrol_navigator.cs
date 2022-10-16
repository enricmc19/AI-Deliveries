using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol_navigator : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        Position();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            Waypoints();
            Position();
        }
    }

    void Position()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target); 

    }
    
    void Waypoints()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
