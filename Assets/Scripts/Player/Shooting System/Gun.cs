using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    public delegate void ShootAction();
    public static event ShootAction OnShoot;

    [SerializeField] protected float bulletSpeed; // bullet speed
    [SerializeField] protected int currentAmmo; // current amount bullets in the gun
    [SerializeField] protected int magazine; // magazine our weapon
    [SerializeField] protected int damage = 25; // damage which we inflict to the enemy
    [SerializeField] protected float reloadTime; // time before start reloading and finished
    [SerializeField] protected Transform gunPointer; // the point from which the beam is sent
    [SerializeField] protected float delay; // delay between shootings
    [SerializeField] protected int maxAmmo;
    private float currentDelay; 
    private int reason; // difference between full magazine and some bullets we shooted
    public bool isReloading;
    private int residue; //difference between full magazine and some bullets we shooted
    private Animator animator; // animator our player
    public bool isShooting;
    [SerializeField] float range = 100f; // rang we can shoot
    [SerializeField] ParticleSystem muzzleFlash; // particle system
    [SerializeField] GameObject hitEffectWall; // hit enviroment
    [SerializeField] GameObject hitEffectBlood; // hit enemy
    [SerializeField] private AudioClip[] fxSound;
    AudioSource audioSourcePlayer;


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

        OnShoot?.Invoke();
    }

    public void Reload()
    {
        if (isReloading || maxAmmo<=0)
        {
            return;
        }
        isReloading = true;
        StartCoroutine(PerformReload());        
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
