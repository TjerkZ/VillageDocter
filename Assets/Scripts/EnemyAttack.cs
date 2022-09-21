using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f; // How much damage the enemy deals

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>(); // Get correct component to apply damage to player/ target
    }

    // Deal damage to the player
    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage); // Deal damage to target
    }
}
