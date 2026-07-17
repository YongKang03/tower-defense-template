using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public StatData healthData;
    public StatData energyData;
    public StatData energyRegenData;

    public HealthStat healthStat;
    public EnergyStat energyStat;
    public EnergyRegenStat energyRegenStat;
    public GunCooldownStat gunCooldownStat;

    private Dictionary<StatID, Stat> stats = new Dictionary<StatID, Stat>();

    public GunManager gunManager;

    void Awake()
    {
        InitializeStat();
        AddStatDictionary();
    }

    void InitializeStat()
    {
        if (healthData != null)
            healthStat = new HealthStat(healthData.maxValue);

        if (energyData != null)
            energyStat = new EnergyStat(energyData.maxValue);

        if (energyRegenData != null)
            energyRegenStat = new EnergyRegenStat(energyRegenData.maxValue);

        if (gunCooldownStat == null)
            gunCooldownStat = new GunCooldownStat(0f);
    }

    void AddStatDictionary()
    {
        if (healthStat != null)
            stats.Add(StatID.Health, healthStat);
        if (energyStat != null)
            stats.Add(StatID.Energy, energyStat);
        if (energyRegenStat != null)
            stats.Add(StatID.EnergyRegen, energyRegenStat);
        if (gunCooldownStat != null)
            stats.Add(StatID.GunCooldown, gunCooldownStat);
    }

    void OnEnable()
    {
        if (gunManager != null)
            gunManager.OnGunEquipped += OnGunEquippedHandler;
    }

    void OnDisable()
    {
        if (gunManager != null)
            gunManager.OnGunEquipped -= OnGunEquippedHandler;
    }

    void OnGunEquippedHandler(Gun gun)
    {
        if (gun == null) return;

        gunCooldownStat.Configure(gun.data.cooldown.maxValue);
    }

    void Update()
    {
        if (energyStat != null)
        {
            RegenerateEnergy();
        }
    }

    public void TakeDamage(float amount)
    {
        healthStat.Modify(-amount);
    }

    public bool CanConsumeEnergy(float amount)
    {
        return energyStat.currentValue >= amount;
    }

    public void ConsumeEnergy(float amount)
    {
        energyStat.Modify(-amount);
    }

    void RegenerateEnergy()
    {
        energyStat.Modify(energyRegenStat.maxValue * Time.deltaTime);
    }

    public Stat ReadStat(StatID statID)
    {
        stats.TryGetValue(statID, out var stat);
        return stat;
    }
}
