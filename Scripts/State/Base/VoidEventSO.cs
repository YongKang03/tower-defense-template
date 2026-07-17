using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/VoidEvent")]
public class VoidEventSO : ScriptableObject
{
    public event Action OnEventRaised;

    public void InvokeEvent()
    {
        OnEventRaised?.Invoke();
    }
}
