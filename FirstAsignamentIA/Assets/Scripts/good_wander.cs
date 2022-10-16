using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class good_wander : MonoBehaviour
{
    public float wanderRadius; // Unit limiter for the area where the AI will find a new position
    public float wanderTimer; // This wanderTimer is used in order to make our AI look for a new position avoiding getting stuck in some place without a possible exit

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer) //When timer exceeds wanderTimer we look for a new position
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 futureDirection = UnityEngine.Random.insideUnitSphere * dist;

        futureDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(futureDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
