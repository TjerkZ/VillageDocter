using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HP = 100f;
    [SerializeField] int currentBody = 0;
    public static bool Dead;

    private void Start()
    {
        Dead = false;
    }

    public void TakeDamage(float damage)
    {
        //BroadcastMessage("OnDamageTaken");
        HP -= damage;
        if (HP <= 0)
        {
            //Destroy(gameObject);
            //GetComponent<Animator>().SetBool("CanAttack", false);
            //GetComponent<Animator>().SetBool("Dead", true);
            //CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
            Destroy(gameObject);
            Dead = true;
        }
    }

    public void HealZombie(float heal)
    {
        int bodies = 1;
        //BroadcastMessage("OnDamageTaken");
        HP += heal;
        if (HP > 100)
        {
            currentBody = 1;
            foreach (Transform body in transform)
            {
                if (bodies == currentBody)
                {
                    GetComponent<EnemyAI>().BecomeScared();
                    body.gameObject.SetActive(true);
                }

            }
        }
    }
}

