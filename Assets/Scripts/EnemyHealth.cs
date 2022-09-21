using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f; // Enemy's health

    // Remove hitPoints
    public void TakeDamage(float damage)
    {
        BroadcastMessage("Provoke");
        hitPoints -= damage;
        if (hitPoints <= 0) // If no health left, destroy enemy object
        {
            Destroy(gameObject);
        }
    }
}
