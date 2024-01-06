using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected int currentAmmo; // current amount bullets in the gun
    [SerializeField] protected int maxAmmoStart = 30; // 
    [SerializeField] protected int magazine;
    [SerializeField] protected int damage = 25;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected Transform gunPointer;
    [SerializeField] protected Rigidbody bulletPrefab;
    [SerializeField] protected float delay;
    
    protected float currentDelay;
    protected int reason; // difference between full magazine and some bullets we shooted
    public bool isReloading;
    protected int residue; //difference between full magazine and some bullets we shooted
    public Animator animator;
    public bool isShooting;

    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffectWall;
    [SerializeField] GameObject hitEffectBlood;

    [SerializeField] private AudioClip[] fxSound;
    AudioSource audioSourcePlayer;

    protected int maxAmmo;

    private void Awake()
    {    
        audioSourcePlayer = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (currentAmmo > 0 && isShooting)
        {
            Shoot();     
        }
        else
        {
            currentDelay -= Time.deltaTime;
        }

        if (isReloading)
        {

            Reload();
            audioSourcePlayer.PlayOneShot(fxSound[1]);
            //audioSourcePlayer.PlayOneShot(fxSound[2]);
            audioSourcePlayer.PlayOneShot(fxSound[3]);
            
            return;
        }

    }

    public void Shoot()
    {
        if (currentDelay > 0 )
        {
            return;
        }
     
        PlayMuzzleFlash();
        ProcessRaycast();
        Debug.Log("Shooting");
        audioSourcePlayer.PlayOneShot(fxSound[0]);

        currentDelay = delay;
        currentAmmo--;
    }

    public void Reload()
    {
        if (isReloading)
        {
            return;
        }
        isReloading = true;

        StartCoroutine(PerformReload());
        Debug.Log("Reloading");
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    public IEnumerator PerformReload()
    {
        
            
        yield return new WaitForSeconds(reloadTime);

        reason = magazine - currentAmmo;
        residue = maxAmmo - reason;
        maxAmmo = residue;
        currentAmmo = magazine;  
        
        isReloading = false;
    }


    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunPointer.transform.position, gunPointer.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            Health target = hit.transform.GetComponent<Health>();
            if (target == null) { return; }
            target.Damage(damage);

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if (hit.transform.tag == "Enemy")
        {
            GameObject impatc = Instantiate(hitEffectBlood, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impatc, 1);

        }
        else
        {
            GameObject impatc = Instantiate(hitEffectWall, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impatc, 1);
        }

    }

}
