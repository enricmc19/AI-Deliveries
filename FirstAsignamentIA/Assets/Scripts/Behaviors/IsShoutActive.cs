using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework; 

[Condition("MyConditions/Is Shout Active?")]
[Help("Checks whether shout is active")]
public class IsShoutActive : ConditionBase
{
    [InParam("shout")]
    [Help("Bool which alarms the cop to pursue the robber")]
    public bool shout;
    public override bool Check()
    {
        GameObject robber = GameObject.Find("robbber");
        GameObject treasure = GameObject.Find("Present-01");
        if(Vector3.Distance(robber.transform.position, treasure.transform.position) < 10f)
        {
            shout=true;
        }
        return shout;
    }
} 
