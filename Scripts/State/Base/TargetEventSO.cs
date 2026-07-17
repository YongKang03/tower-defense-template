using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/TargetEvent")]
public class TargetEventSO : ScriptableObject
{
    public event Action<ITargetable> OnEventRaised;

    public void InvokeEvent(ITargetable target)
    {
        OnEventRaised?.Invoke(target);
    }
}
