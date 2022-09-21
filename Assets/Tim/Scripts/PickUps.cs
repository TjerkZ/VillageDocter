using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] Canvas PickUpCanvas;
    [SerializeField] Transform target;
    [SerializeField] float distanceToTarget;

    void Start()
    {
        PickUpCanvas.enabled = false;
    }

    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget < 2)
        {
            PickUpCanvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickUpCanvas.enabled = false;
                Destroy(gameObject);
                //GetComponent<Inventory>().AddItemToInventory();
            }
        }
        else
        {
            PickUpCanvas.enabled = false;
        }
    }
}
