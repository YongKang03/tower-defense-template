using UnityEngine;

[CreateAssetMenu(menuName = "Behaviour/EnableShoot")]
public class EnableShootBehaviour : StateBehaviourSO
{
    public override void UpdateState(TurretV2 context)
    {
        context.EnableShoot();
    }
}
