using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private int damage = 20;

    AudioSource audioSourceEnemy;
    EnemyAI enemyAI;

    public event Action OnShoot;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        audioSourceEnemy = GetComponent<AudioSource>();
        enemyAI = GetComponent<EnemyAI>();
    }

    private void AttackHitEvent()
    {
        if (target == null) return;
        OnShoot?.Invoke();
        audioSourceEnemy.PlayOneShot(enemyAI.FxSound[0]);
    }
}
