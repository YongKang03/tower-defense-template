using UnityEngine;

[CreateAssetMenu(menuName = "Condition/CheckRotation")]
public class CheckRotationBehaviour : ConditionSO
{
    public override bool Evaluate(TurretV2 context)
    {
        return context.IsRotationComplete();
    }
}
