using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public abstract class Gun : MonoBehaviour
{
    
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected bool IsReloading;
    [SerializeField] protected int magazine; // current amount bullets in the gun
    [SerializeField] protected int maxMagazine; // amount bullets which has 
    [SerializeField] protected float damage;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected Transform gunPointer;
    [SerializeField] protected Rigidbody bulletPrefab;
    [SerializeField] protected float delay;
     protected float currentDelay;
     protected int reason; // difference between full magazine and some bullets we shooted


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            Debug.Log(magazine);
        }
        else
        {
            currentDelay -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R) && maxMagazine > 0)
        {
            Reload();
        }

    }
   
    
    public void Shoot()
    {
        if (currentDelay > 0)
            return;

        Rigidbody bulletInstance = Instantiate(bulletPrefab, gunPointer.position, gunPointer.rotation);
        bulletInstance.velocity = gunPointer.forward * bulletSpeed;
        currentDelay = delay;
       
    }

    public abstract void Reload();

    

}
