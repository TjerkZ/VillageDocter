using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPickup : MonoBehaviour
{
    [SerializeField] Canvas PickUpEggCanavs;
    [SerializeField] float distanceToTarget;
    [SerializeField] Transform target;
    [SerializeField] public static float amountOfEggs;

    void Start()
    {
        PickUpEggCanavs.enabled = false;
        amountOfEggs = 0;
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= 2)
        {
            PickUpEggCanavs.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);
                PickUpEggCanavs.enabled = false;
                amountOfEggs++;
            }
        }
        else
        {
            PickUpEggCanavs.enabled = false;
        }
    }
}
