using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Authority avoided?")]
[Help("Checks whether Cop is near the robber.")]
public class IsAuthorityNear : ConditionBase
{
    public override bool Check()
    {
        GameObject cop = GameObject.Find("Cop");
        GameObject robber = GameObject.Find("Robber");
        return Vector3.Distance(cop.transform.position, robber.transform.position) < 5f;
    }
}
