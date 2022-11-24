using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour
{
    public Transform Santa;
    public GameObject target;
    public float dist2bench = 10f;
    Moves moves;
    UnityEngine.AI.NavMeshAgent agent;

    float waitTimer = 0.05f;
    private WaitForSeconds wait = new WaitForSeconds(0.05f); // == 1/20
    delegate IEnumerator State();
    private State state;

    IEnumerator Start()
    {
        moves = gameObject.GetComponent<Moves>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        yield return wait;

        state = Wander;

        while (enabled)
            yield return StartCoroutine(state());
    }

    IEnumerator Wander()
    {


        while (Vector3.Distance(Santa.position, target.transform.position) < dist2bench)
        {
            moves.Wander();
            yield return wait;
        };

        state = Approaching;
    }

    IEnumerator Approaching()
    {


        agent.speed = 3.5f;
        moves.Seek(target.transform.position);

        bool sitting = false;
        while (Vector3.Distance(Santa.position, target.transform.position) > dist2bench)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < 2f)
            {
                sitting = true;
                break;
            };
            yield return wait;
        };

        if (sitting)
        {
            state = SitState;
        }
        else
        {
            agent.speed = 1f;
            state = Wander;
        }
    }


    IEnumerator SitState()
    {
        float timeSit = 0;
        float i = 0;


        while (true)
        {
            if ((timeSit += waitTimer) > 10) { state = Wander; }
            agent.speed = 0f;
            yield return wait;
        };
    }
}