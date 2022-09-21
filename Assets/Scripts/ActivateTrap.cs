using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    [SerializeField] private float slowPower = 1.5f; // The speed target gets set to when slowed (the lower the better)
    [SerializeField] private float slowDuration = 3000f; // How long the slow effect lasts

    private EnemyAI target;

    // OnTriggerEnter is called everytime the collider of the GameObject collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if collision is with enemy, if so start Attack animation
        if (other.CompareTag("Enemy"))
        {
            target = other.transform.GetComponent<EnemyAI>();
            transform.GetComponent<Animator>().SetBool("Attack", true); // Start Attack animation
        }
    }

    // Slow down enemy
    private void Attack()
    {
        if (target != null)
        {
            target.ChangeSpeed(slowPower, slowDuration);
            target.Provoke();
        }
    }

    // Delete trap
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
