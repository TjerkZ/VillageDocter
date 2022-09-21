using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrap : MonoBehaviour
{
    [SerializeField] private GameObject trap;
    [SerializeField] private Transform cams;
    [SerializeField] private LayerMask environment;
    [SerializeField] private float trapPlaceRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit Hit;
            if (Physics.Raycast(cams.position, cams.forward, out Hit, trapPlaceRange, environment))
            {
                GameObject trapPlaced = Instantiate(trap, Hit.point + Hit.normal * 0.001f, Quaternion.identity) as GameObject;
                trapPlaced.transform.LookAt(Hit.point + Hit.normal);
            }
        }
    }
}
