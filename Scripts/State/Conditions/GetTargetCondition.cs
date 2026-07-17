using UnityEngine;

[CreateAssetMenu(menuName = "Condition/GetTarget")]
public class GetTargetCondition : ConditionSO
{
    public override bool Evaluate(TurretV2 context)
    {
        return context.GetTarget() != null;
    }
}
