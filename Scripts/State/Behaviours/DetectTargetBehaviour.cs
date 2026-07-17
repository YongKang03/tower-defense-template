using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/DetectTarget")]
public class DetectTargetBehaviour : StateBehaviourSO
{
    public float detectionRange;

    public override void UpdateState(TurretV2 context)
    {
        context.DetectTarget(detectionRange);
    }
}
