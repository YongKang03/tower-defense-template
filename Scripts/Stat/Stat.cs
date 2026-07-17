using System;
using UnityEngine;

public abstract class Stat
{
    public int statID;
    public float currentValue;
    public float maxValue;

    public event Action OnValueChanged;

    protected Stat(float maxValue)
    {
        this.maxValue = maxValue;
        currentValue = maxValue;
    }

    public virtual void Modify(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxValue);
        OnValueChanged?.Invoke();
    }

    public virtual void Configure(float newMax)
    {
        maxValue = newMax;
        currentValue = 0;
        OnValueChanged?.Invoke();
    }
}