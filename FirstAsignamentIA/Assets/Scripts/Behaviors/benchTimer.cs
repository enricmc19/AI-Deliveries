using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Bench Time")]
[Help("Checks whether Robber is near the oldman and sets timer.")]
public class BenchTime : ConditionBase
{
    public override bool Check()
    {
        GameObject robber = GameObject.Find("Robber");
        GameObject target = GameObject.Find("Bench");
        GameObject oldman = GameObject.Find("Santa");

        int benchTimer = 0;
        bool benchTime=false;

        if (Vector3.Distance(oldman.transform.position, target.transform.position) < 0.5f)
        {
            for(int i = 0; benchTimer < 10; i++)
            {
                int y = benchTimer++;
            }
        }
           
        if (benchTimer == 10) { benchTime=true; }

        return benchTime;
    }
}
