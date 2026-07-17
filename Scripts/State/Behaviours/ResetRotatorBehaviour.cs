using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/ResetRotator")]
public class ResetRotatorbehaviour : StateBehaviourSO
{
    public override void UpdateState(TurretV2 context)
    {
        context.ResetRotator();
    }
}
