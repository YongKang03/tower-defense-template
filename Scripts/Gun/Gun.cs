using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunData data;
    public Bullet bullet;
    public Transform firingPoint;
    public float EnergyCost => data.energyCost;
    public float Cooldown => data.cooldown.maxValue;

    /*
    The line of code "public float EnergyCost => data.energyCost;" is equivalent to:

    public float EnergyCost
    {
        get
        {
            return data.energyCost;
        }
    }
    */

    private Stat cooldownStat;

    public void Init(Stat cooldownStat)
    {
        this.cooldownStat = cooldownStat;
    }

    public void ShootBullet()
    {
        Instantiate(bullet, firingPoint.position, firingPoint.rotation);
    }

    public bool CanConsumeCooldown()
    {
        return cooldownStat.currentValue == cooldownStat.maxValue;
    }

    public void ConsumeCooldown()
    {
        cooldownStat.Modify(-cooldownStat.maxValue);
    }

    public void RegenerateCooldown()
    {
        cooldownStat.Modify(Time.deltaTime);
    }
}
