using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{

    [SerializeField] GameObject revolverPlayer;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
                
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

        if (Physics.Raycast(revolverPlayer.transform.position, revolverPlayer.transform.forward, out hit, range))
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
