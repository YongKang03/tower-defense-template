using UnityEngine;

public class TurretV2 : MonoBehaviour, IBrain, IStateManager
{
    public Detector detector;
    public HeadStateManager headStateManager;
    public WeaponStateManager weaponStateManager;

    StateMachineV2 stateMachine;
    [SerializeField] StateSO idleState;
    [SerializeField] StateSO activeState;

    private void Awake()
    {
        stateMachine = new StateMachineV2(this);
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

    public void DetectTarget(float detectionRange)
    {
        detector.DetectTarget(detectionRange);
    }

    public ITargetable GetTarget()
    {
        return detector.GetTarget();
    }

    public void ResetRotator()
    {
        headStateManager.ResetRotator();
    }

    public void RotateToTarget(float rotationSpeed)
    {
        headStateManager.RotateToTarget(rotationSpeed);
    }

    public bool IsRotationComplete()
    {
        return headStateManager.IsRotationComplete();
    }

    public void EnableShoot()
    {
        weaponStateManager.EnableShoot();
    }
}
