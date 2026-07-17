public class StateMachineV2
{
    public StateSO currentState;
    TurretV2 context;

    public StateMachineV2(TurretV2 context)
    {
        this.context = context;
    }

    public void InitializeState(StateSO initialState)
    {
        currentState = initialState;
        currentState.EnterState(context, this);
    }

    public void Update()
    {
        currentState.UpdateState(context, this);
    }

    public void SwitchState(StateSO newState)
    {
        if (newState == currentState)
            return;

        currentState.ExitState(context, this);
        currentState = newState;
        currentState.EnterState(context, this);
    }
}