using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected bool IsReloading;
    [SerializeField] protected int currentAmmo; // current amount bullets in the gun
    [SerializeField] protected int maxAmmo; // 
    [SerializeField] protected int magazine;
    [SerializeField] protected float damage;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected Transform gunPointer;
    [SerializeField] protected Rigidbody bulletPrefab;
    [SerializeField] protected float delay;
    protected float currentDelay;
    protected int reason; // difference between full magazine and some bullets we shooted
    protected bool isReloading = false;
    protected int residue; //difference between full magazine and some bullets we shooted
    public Animator animator;
    protected bool isShooting = false;
        


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    private void Update()
    {
       
        if (isReloading)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && maxAmmo > 0 )
        {
            StartCoroutine(Reload());
            Debug.Log($"maxAmmo {maxAmmo}");
            return;
        }
        if (Input.GetMouseButtonDown(0) && currentAmmo>0)
        {           
            Shoot();        
            Debug.Log(currentAmmo);            
        }
        else
        { 
            currentDelay -= Time.deltaTime;
        }
        


    }
   
    
    public void Shoot()
    {
        if (currentDelay > 0)
            return;

        Rigidbody bulletInstance = Instantiate(bulletPrefab, gunPointer.position, gunPointer.rotation);
        bulletInstance.velocity = gunPointer.forward * bulletSpeed;
        currentDelay = delay;
        currentAmmo--;
        
       
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        reason = magazine - currentAmmo;
        residue = maxAmmo - reason;
        maxAmmo = residue;
        currentAmmo = magazine;
        isReloading = false;




    }

    

}
