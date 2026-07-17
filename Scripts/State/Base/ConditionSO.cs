using UnityEngine;

public abstract class ConditionSO : ScriptableObject
{
    public abstract bool Evaluate(TurretV2 context);
}