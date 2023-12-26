using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] int damage = 20;

    AudioSource audioSourceEnemy;
    EnemyAI enemyAI;

    public event Action OnShoot;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        audioSourceEnemy = GetComponent<AudioSource>();
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        OnShoot?.Invoke();
        audioSourceEnemy.PlayOneShot(enemyAI.FxSound[0]);
        Debug.Log("bang bang");
    }
}
