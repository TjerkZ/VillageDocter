//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Weapons : MonoBehaviour
//{
//    [SerializeField] Camera FPCamera;
//    [SerializeField] float range = 100f;
//    [SerializeField] float damage = 25f;
//    [SerializeField] Ammo ammoSlot;

//    void Update()
//    {
//        Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.forward, Color.black);
//        if (Input.GetMouseButtonDown(0))
//        {
//            Shoot();
//        }
//    }

//    private void Shoot()
//    {
//        if (ammoSlot.GetCurrentAmmo() > 0)
//        {
//            RaycastProcess();
//            ammoSlot.ReduceCurrentAmmo();
//        }
//    }

//    private void RaycastProcess()
//    {
//        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out RaycastHit hit, range))
//        {
//            Debug.Log("I hit " + hit.transform.name);
//            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
//            if (enemy == null)
//            {
//                return;
//            }
//            enemy.TakeDamage(damage);
//        }
//        else
//        {
//            Debug.Log("miss");
//            return;
//        }

//    }
//}
