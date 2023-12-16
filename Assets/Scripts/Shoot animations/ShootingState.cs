using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        aim.animator.SetBool("Shooting", true);
    }

    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            aim.SwitchState(aim.Aim);
        }
    }
}
