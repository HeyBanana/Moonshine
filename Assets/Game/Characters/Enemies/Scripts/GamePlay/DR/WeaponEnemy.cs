using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{

    [SerializeField] GameObject revolverEnemy;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] EnemyAttack enemyAttack;


    private void Start()
    {
        enemyAttack.OnShoot += Shoot;
    }

    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}
                
    }

    private void OnDestroy()
    {
        enemyAttack.OnShoot -= Shoot;
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(revolverEnemy.transform.position, revolverEnemy.transform.forward, out hit, range))
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
        GameObject impatc = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impatc, 1);
    }
}
