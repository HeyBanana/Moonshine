using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour, IFSMNaming
{
    public event EventHandler OnSpacePressed;
    public event Action<State> OnCurrentState;

    NavMeshAgent agent;
    Animator anim;
    State currentState;

    public Transform player;

    public string NameFSM
    {
        get { return "FSM Unity"; }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentState = new Idle(gameObject, agent, anim, player);

    }

    void Update()
    {
        currentState = currentState.Process();

        OnCurrentState?.Invoke(currentState);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);

        }

    }
}
