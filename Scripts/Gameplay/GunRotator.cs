using UnityEngine;

public class GunRotator : MonoBehaviour
{
    public GameObject rotatorPrefeb;
    public float rotationSpeed = 360f;
    public float returnRotationSpeed = 10f;
    public float angleThreshold = 2.0f;
    private Quaternion defaultRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultRotation = rotatorPrefeb.transform.rotation;
    }

    public void RotateToTarget(Transform target, float rotationSpeed)
    {
        Vector3 dir = target.position - rotatorPrefeb.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);
        rotatorPrefeb.transform.rotation = Quaternion.RotateTowards(rotatorPrefeb.transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
    }

    public bool IsRotationComplete(Transform target)
    {
        Vector3 dirToTarget = (target.position - rotatorPrefeb.transform.position).normalized;
        float angle = Vector3.Angle(rotatorPrefeb.transform.forward, dirToTarget);
        return angle < angleThreshold;
    }

    public void ResetRotator()
    {
        if (rotatorPrefeb.transform.rotation != defaultRotation)
            rotatorPrefeb.transform.rotation = Quaternion.Slerp(rotatorPrefeb.transform.rotation, defaultRotation, Time.deltaTime * returnRotationSpeed);
    }
}
