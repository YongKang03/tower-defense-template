using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/InvokeVoidEvent")]
public class InvokeVoidEventBehaviourSO : StateBehaviourSO
{
    [SerializeField] VoidEventSO eventToInvoke;

    public override void EnterState(TurretV2 context)
    {
        eventToInvoke.InvokeEvent();
    }
}