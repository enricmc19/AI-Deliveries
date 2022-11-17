using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Bench Near?")]
[Help("Checks whether a bench is near the Treasure.")]
public class IsBenchNear : ConditionBase
{
    public override bool Check()
    {
        GameObject oldman = GameObject.Find("Santa");
        GameObject target = GameObject.Find("Bench");
        return Vector3.Distance(oldman.transform.position, target.transform.position) < 20f;
    }
}
