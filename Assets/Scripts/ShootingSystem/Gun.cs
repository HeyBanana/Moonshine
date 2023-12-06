using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public abstract class Gun : MonoBehaviour
{

    public float bulletSpeed; 
    public bool IsReloading;
    public float magazine; // current amount bullets in the gun
    public float maxMagazine; // amount bullets which has player
    public float reason; // difference between full magazine and some bullets we shooted
    public float damage;
    public float reloadTime; 
    public float lastTimeShoot = 0; 
    public Transform gunPointer;
    public Rigidbody bulletPrefab;
   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Rigidbody bulletInstance = Instantiate(bulletPrefab, gunPointer.position, gunPointer.rotation);
        bulletInstance.velocity = gunPointer.forward * bulletSpeed;
       
    }

    public abstract void Reload();

    

}
