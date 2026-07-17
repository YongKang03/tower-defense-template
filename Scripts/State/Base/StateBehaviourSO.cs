using UnityEngine;

public class StateBehaviourSO : ScriptableObject
{
    public virtual void EnterState(TurretV2 context) { }
    public virtual void UpdateState(TurretV2 context) { }
    public virtual void ExitState(TurretV2 context) { }

    public virtual void EnterState(TurretV2 context, StateMachineV2 machine)
    => EnterState(context);

    public virtual void UpdateState(TurretV2 context, StateMachineV2 machine)
        => UpdateState(context);

    public virtual void ExitState(TurretV2 context, StateMachineV2 machine)
        => ExitState(context);
}