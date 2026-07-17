using UnityEngine;

public class WeaponStateManager : MonoBehaviour, IStateManager
{
    public TurretV2 turret;
    public StatManager statManager;
    public GunManager gunManager;

    StateMachineV2 stateMachine;
    [SerializeField] StateSO idleState;
    [SerializeField] StateSO activeState;

    [SerializeField] VoidEventSO OnTargetLocked;
    [SerializeField] VoidEventSO OnTargetNotLocked;

    private void Awake()
    {
        stateMachine = new StateMachineV2(turret);
    }

    private void OnEnable()
    {
        OnTargetLocked.OnEventRaised += OnTargetLockedHandler;
        OnTargetNotLocked.OnEventRaised += OnTargetNotLockedHandler;
    }
    private void OnDisable()
    {
        OnTargetLocked.OnEventRaised -= OnTargetLockedHandler;
        OnTargetNotLocked.OnEventRaised -= OnTargetNotLockedHandler;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine.InitializeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {   
        stateMachine.Update();
    }

    public void SwitchState(StateSO newState)
    {
        stateMachine.SwitchState(newState);
    }

    public void OnTargetLockedHandler()
    {
        SwitchState(activeState);
    }

    public void OnTargetNotLockedHandler()
    {
        SwitchState(idleState);
    }

    public void EnableShoot()
    {
        if (statManager.CanConsumeEnergy(gunManager.currentGun.EnergyCost) && gunManager.currentGun.CanConsumeCooldown())
        {
            gunManager.currentGun.ShootBullet();
            statManager.ConsumeEnergy(gunManager.currentGun.EnergyCost);
            gunManager.currentGun.ConsumeCooldown();
            Debug.Log("Shooted!");
        }
    }
}
