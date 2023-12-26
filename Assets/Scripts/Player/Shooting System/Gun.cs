using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public abstract class Gun : MonoBehaviour
{

    [SerializeField] protected float bulletSpeed;
    [SerializeField] public int currentAmmo; // current amount bullets in the gun
    [SerializeField] public int maxAmmo; // 
    [SerializeField] public int magazine;
    [SerializeField] protected int damage = 25;
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

    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffectWall;
    [SerializeField] GameObject hitEffectBlood;

    [SerializeField] private AudioClip[] fxSound;
    AudioSource audioSourcePlayer;




    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSourcePlayer = GetComponent<AudioSource>();



    }
    private void Update()
    {

        if (isReloading)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && maxAmmo > 0)
        {
            StartCoroutine(Reload());
            audioSourcePlayer.PlayOneShot(fxSound[1]);
            audioSourcePlayer.PlayOneShot(fxSound[2]);
            audioSourcePlayer.PlayOneShot(fxSound[3]);
            Debug.Log($"maxAmmo {maxAmmo}");
            return;
        }
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
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

        //Rigidbody bulletInstance = Instantiate(bulletPrefab, gunPointer.position, gunPointer.rotation);
        //bulletInstance.velocity = gunPointer.forward * bulletSpeed;

        PlayMuzzleFlash();
        ProcessRaycast();
        audioSourcePlayer.PlayOneShot(fxSound[0]);

        currentDelay = delay;
        currentAmmo--;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
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
