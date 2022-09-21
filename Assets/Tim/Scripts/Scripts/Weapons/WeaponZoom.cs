using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera zoomCamera;
    [SerializeField] float fovZoomedOut;
    [SerializeField] float fovZoomedIn;
    RigidbodyFirstPersonController controller;

    private void Start()
    {
        controller = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            zoomCamera.fieldOfView = fovZoomedIn;
        }
        else
        {
            zoomCamera.fieldOfView = fovZoomedOut;
        }
    }
}
