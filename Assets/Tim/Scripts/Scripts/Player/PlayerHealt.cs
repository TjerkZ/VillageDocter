using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] float HP = 100f;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Debug.Log("Get F*cked");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
