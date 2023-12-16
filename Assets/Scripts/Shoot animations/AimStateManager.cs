using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
   AimBaseState currentState;
   public  AimState Aim = new AimState();
   public  ShootingState Shooting = new ShootingState();


    public Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        SwitchState(Aim);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);  
    }
    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
