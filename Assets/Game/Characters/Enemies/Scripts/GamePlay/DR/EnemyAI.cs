using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 6f;
    [SerializeField] private Health heatlth;
    [SerializeField] private AudioClip[] fxSound;
    
    AudioSource audioSourceEnemy;
    NavMeshAgent navMeshAgent;
    Animator animator;

    public AudioClip[] FxSound { get { return fxSound; } }

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSourceEnemy = GetComponent<AudioSource>();
        heatlth = GetComponent<Health>();

        heatlth.OnReaction += Reaction;
        heatlth.OnDieBecome += OnDie;
    }

    private void Update()
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
        heatlth.OnReaction -= Reaction;
        heatlth.OnDieBecome -= OnDie;
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
        animator.SetTrigger("onReaction");
        audioSourceEnemy.PlayOneShot(fxSound[4]);
    }

    private void Reload()
    {
        animator.SetTrigger("onReload");
        audioSourceEnemy.PlayOneShot(fxSound[1]);
        audioSourceEnemy.PlayOneShot(fxSound[3]);
    }

    private void OnDie()
    {
        animator.SetTrigger("onDie");
        audioSourceEnemy.PlayOneShot(fxSound[5]);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
