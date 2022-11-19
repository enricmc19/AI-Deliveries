using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Active True?")]
[Help("Checks whether Present is Active.")]
public class IsActiveTrue : ConditionBase
{
    public override bool Check()
    {
        GameObject treasure = GameObject.Find("Present-01");


        return !treasure.active;
    }
}
