using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    GunEnemy gunEnemy;
    NavMeshAgent agent;
    Transform target;

    public float lookRadius = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform ;

    
    }
    void Update()
    {
        UpdatePath();
    }
    void UpdatePath()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)// следует только в определенном радиусе
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                //Attack the target
                FaceTarget();
                gunEnemy.Shoot();
            }
        }
    }


    void FaceTarget()
    {
        
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
