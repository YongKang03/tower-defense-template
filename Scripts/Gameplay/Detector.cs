using UnityEngine;

public class Detector : MonoBehaviour
{
    public float detectionRange;
    ITargetable currentTarget;

    public void DetectTarget(float detectionRange)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRange);
        currentTarget = null;
        float closestDist = float.MaxValue;

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<ITargetable>(out var target))
            {
                float dist = Vector3.Distance(transform.position, ((MonoBehaviour)target).transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    currentTarget = target;
                }
            }
        }
    }

    public ITargetable GetTarget()
    {
        return currentTarget;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
