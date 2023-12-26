using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour, IFSMNaming
{
    public event EventHandler OnSpacePressed;
    public event Action<State> OnCurrentState;

    AudioSource audioSourceEnemy;
    Health heatlth;
    AI enemyAI;

    NavMeshAgent agent;
    Animator anim;
    State currentState;

    public Transform player;

    [SerializeField] private AudioClip[] fxSound;
    public AudioClip[] FxSound { get { return fxSound; } }

    public string NameFSM
    {
        get { return "FSM Unity"; }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        audioSourceEnemy = GetComponent<AudioSource>();
        heatlth = GetComponent<Health>();
        heatlth.OnReaction += Reaction;
        heatlth.OnDieBecome += OnDie;
        enemyAI = GetComponent<AI>();

        currentState = new Idle(gameObject, agent, anim, player, audioSourceEnemy, heatlth, enemyAI);

    }

    private void Update()
    {
        currentState = currentState.Process();

        OnCurrentState?.Invoke(currentState);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);

        }

    }

    private void Reaction()
    {
        anim.SetTrigger("onReaction");
        audioSourceEnemy.PlayOneShot(fxSound[4]);
    }

    private void OnDie()
    {
        anim.SetTrigger("onDie");
        audioSourceEnemy.PlayOneShot(fxSound[5]);
    }
}
