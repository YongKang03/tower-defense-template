using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/RotateToTarget")]
public class RotateToTargetBehaviour : StateBehaviourSO
{
    public float rotationSpeed;

    public override void UpdateState(TurretV2 context)
    {
        context.RotateToTarget(rotationSpeed);
    }
}
