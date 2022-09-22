using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log("Player has: " + hitPoints + " hit points left");
        if (hitPoints <= 0)
        {
            Debug.Log("Player died");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
