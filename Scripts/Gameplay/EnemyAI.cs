using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, ITargetable, IDamageable
{
    public StatManager statManager;
    public float walkRadius = 10f;
    private NavMeshAgent agent;
    private bool ok = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            ok = false;
            SetRandomDestination();
        }
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    public void TakeDamage(int amount)
    {
        statManager.TakeDamage(amount);

        if (statManager.healthStat.currentValue <= 0)
            Destroy(gameObject);
    }

    void SetRandomDestination()
    {
        while(ok == false)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * walkRadius;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, 2f, NavMesh.AllAreas))
            {
                NavMeshPath path = new NavMeshPath();

                if (agent.CalculatePath(hit.position, path) &&
                    path.status == NavMeshPathStatus.PathComplete)
                {
                    agent.SetDestination(hit.position);
                    ok = true;
                    return;
                }
            }

        }
    }
}
