using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{

    [SerializeField] private GameObject revolverPlayer;
    [SerializeField] private float range = 100f;
    [SerializeField] private int damage = 25;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffectWall;
    [SerializeField] private GameObject hitEffectBlood;
    private void Update()
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
