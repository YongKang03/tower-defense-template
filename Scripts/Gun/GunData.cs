using UnityEngine;

[CreateAssetMenu(menuName = "Data/GunData")]
public class GunData : ScriptableObject
{
    public Bullet bullet;
    public float energyCost;
    public StatData cooldown;
}
