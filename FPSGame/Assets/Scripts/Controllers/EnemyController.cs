using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    NavMeshAgent pathFinder;
    Transform target;

    public float lookRadius = 5f;

    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
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
            pathFinder.SetDestination(target.position);
            if (distance <= pathFinder.stoppingDistance)
            {
                //Attack the target
                FaceTarget();
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
