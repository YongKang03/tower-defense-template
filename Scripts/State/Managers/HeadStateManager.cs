using UnityEngine;

public class HeadStateManager : MonoBehaviour, IStateManager
{
    public TurretV2 turret;
    public Detector detector;
    public GunRotator rotator;

    StateMachineV2 stateMachine;
    [SerializeField] StateSO idleState;
    [SerializeField] StateSO seekState;
    [SerializeField] StateSO lockState;

    [SerializeField] TargetEventSO OnTargetDetected;
    [SerializeField] VoidEventSO OnTargetLost;

    private void Awake()
    {
        stateMachine = new StateMachineV2(turret);
    }

    private void OnEnable()
    {
        OnTargetDetected.OnEventRaised += OnTargetDetectedHandler;
        OnTargetLost.OnEventRaised += OnTargetLostHandler;
    }

    private void OnDisable()
    {
        OnTargetDetected.OnEventRaised -= OnTargetDetectedHandler;
        OnTargetLost.OnEventRaised -= OnTargetLostHandler;
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

    private void OnTargetDetectedHandler(ITargetable target)
    {
        SwitchState(seekState);
    }
    private void OnTargetLostHandler()
    {
        Debug.LogWarning("Target lost!");
        SwitchState(idleState);
    }

    public void ResetRotator()
    {
        rotator.ResetRotator();
    }

    public void RotateToTarget(float rotationSpeed)
    {
        rotator.RotateToTarget(detector.GetTarget().GetTransform(), rotationSpeed);
    }

    public bool IsRotationComplete()
    {
        return rotator.IsRotationComplete(detector.GetTarget().GetTransform());
    }
}
