using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{

    public float radius;
    public int offset;
    public NavMeshAgent agent=null;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(wander(transform.position, 100.0f, offset));
    }

   
    Vector3 wander(Vector3 origin, float Radius, int offset)
    {
        // parameters: float radius, offset;
        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * Radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        agent.destination = worldTarget;

        NavMeshHit NavHit;


        NavMesh.SamplePosition(localTarget, out NavHit, Radius, offset);

        return NavHit.position;




    }

   /* void Wander()
    {
        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        agent.destination = worldTarget;
    }*/
}
