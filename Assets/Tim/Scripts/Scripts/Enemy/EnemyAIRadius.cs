using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIRadius : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange;
    [SerializeField] float distanceToTarget;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= chaseRange) 
        {
            isProvoked = true;
        }

        if (isProvoked) 
        {
            EngagePlayer();
        }
    }

    private void EngagePlayer()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChasePlayer();
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackPlayer()
    {
        Debug.Log(target.name + "have taken damage");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
