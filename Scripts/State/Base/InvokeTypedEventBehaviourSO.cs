using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/InvokeTargetEvent")]
public class InvokeTargetEventBehaviourSO : StateBehaviourSO
{
    [SerializeField] TargetEventSO eventToInvoke;

    public override void EnterState(TurretV2 context)
    {
        eventToInvoke.InvokeEvent(context.GetTarget());
    }
}