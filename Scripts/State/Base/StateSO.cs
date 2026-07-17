using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateSO")]
public class StateSO : ScriptableObject
{
    public List<StateBehaviourSO> enterStateBehaviours;
    public List<StateBehaviourSO> updateStateBehaviours;
    public List<StateBehaviourSO> exitStateBehaviours;
    public List<TransitionSO> transitions;

    public void EnterState(TurretV2 context, StateMachineV2 stateMachine)
    {
        foreach(var enter in enterStateBehaviours)
        {
            enter.EnterState(context, stateMachine);
        }
    }

    public void UpdateState(TurretV2 context, StateMachineV2 stateMachine)
    {
        foreach (var update in updateStateBehaviours)
        {
            update.UpdateState(context, stateMachine);
        }

        foreach (var t in transitions)
        {
            if (t.condition.Evaluate(context) == t.trueCondition)
            {
                stateMachine.SwitchState(t.newState);
                return;
            }
        }
    }
        
    public void ExitState(TurretV2 context, StateMachineV2 stateMachine)
    {
        foreach (var exit in exitStateBehaviours)
        {
            exit.ExitState(context, stateMachine);
        }
    }
}
