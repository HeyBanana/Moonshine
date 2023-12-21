using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;

    [SerializeField] WeaponEnemy _weaponEnemy;
    [SerializeField] Health _heatlth;


    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _weaponEnemy = GetComponent<WeaponEnemy>();
        _heatlth.OnReaction += Reaction;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;           

        }

    }

    private void OnDestroy()
    {
        _heatlth.OnReaction -= Reaction;
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        transform.LookAt(target.transform);
        animator.SetBool("attack", true);

    }

    private void Reaction()
    {
        animator.SetTrigger("reaction");
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
