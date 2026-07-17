using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunManager : MonoBehaviour
{
    public List<Gun> guns;
    public Gun currentGun;
    public StatManager statManager;

    public event Action<Gun> OnGunEquipped;

    void Start()
    {
        if (currentGun != null)
        {
            OnGunEquipped?.Invoke(currentGun);
            currentGun.Init(statManager.gunCooldownStat);
        }
    }

    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            EquipGun(0);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            EquipGun(1);
        }

        if (currentGun != null)
            currentGun.RegenerateCooldown();
    }

    void EquipGun(int index)
    {
        currentGun = guns[index];
        OnGunEquipped?.Invoke(currentGun);
        currentGun.Init(statManager.gunCooldownStat);
    }
}
