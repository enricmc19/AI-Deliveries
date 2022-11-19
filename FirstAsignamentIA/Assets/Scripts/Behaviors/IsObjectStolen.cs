using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Object Stolen?")]
[Help("Checks whether present is near the robber.")]
public class IsObjectStolen : ConditionBase
{
    public override bool Check()
    {
        GameObject treasure = GameObject.Find("Present-01");
        GameObject robber = GameObject.Find("Robber");
        return Vector3.Distance(treasure.transform.position, robber.transform.position) < 2f;
    }
}
