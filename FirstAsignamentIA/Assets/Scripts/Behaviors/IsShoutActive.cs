using UnityEngine;
 
using Pada1.BBCore;
using Pada1.BBCore.Framework; 

[Condition("MyConditions/Is Shout Active?")]
[Help("Checks whether shout is active")]
public class IsShoutActive : ConditionBase
{
    [InParam("robber")]
    GameObject robber;
    public override bool Check()
    {
        return robber.GetComponent<Moves>().shout;
    }
} 
