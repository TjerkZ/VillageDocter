using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f; // If target is within this range, start chasing
    [SerializeField] float turnSpeed = 5f; // How fast the enemy can turn

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false; // Whether the enemy has been provoked by the player;
    bool isHealed = false;
    // this happens when the player enters the enemy's chaseRange,
    // when the player damages the enemy,
    // or when a trap slows the enemy

    float slowDuration;
    float regularSpeed;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        regularSpeed = navMeshAgent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); // Check how far away the enemy is
        if (isHealed == true)
        {
            Flee();
        }
        else if (isProvoked == true)
        {
            EngageTarget(); // Engage target (chase after or attack)
        }
        else if (distanceToTarget <= chaseRange) // If enemy is within range
        {
            Provoke();
        }
        if (slowDuration > 0) // Slow effect timer
        {
            slowDuration--;
            if (slowDuration == 0) // Reset speed after slow effect ends
            {
                navMeshAgent.speed = regularSpeed;
            }
        }
    }

    public void Flee()
    {
        FaceTarget();
        ChaseTarget();
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            Destroy(gameObject);
        }
    }

    public void BecomeScared()
    {
        Debug.Log("healed");
        isHealed = true;
        target = GameObject.FindWithTag("FleePoint").transform;
    }

    // Engage target (chase after or attack)
    private void EngageTarget()
    {
        FaceTarget(); // Rotate towards target
        if (distanceToTarget >= navMeshAgent.stoppingDistance) // If enemy is out of attack range, chase target
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance) // If enemy is within attack range, start attack
        {
            AttackTarget();
        }
    }

    // Chase after target
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    // Deal damage to target
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    // Rotate towards target
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    // Show visual of chase range when enemy is selected in Unity editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.DrawWireSphere(transform.position, 1.2f);
    }

    // Apply slow effect
    public void ChangeSpeed(float speed, float duration)
    {
        navMeshAgent.speed = speed;
        slowDuration = duration;
    }

    // When enemy starts targeting player
    public void Provoke()
    {
        isProvoked = true;
    }
}
