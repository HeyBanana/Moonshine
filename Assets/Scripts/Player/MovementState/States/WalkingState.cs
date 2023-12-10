using Moonshine.Core;
using UnityEngine;

namespace Moonshine.Player.MovementState.States
{
    public class WalkingState : MovementBaseState
    {
        private const string WalkAnimationParameter = "walking";

        private float walkSpeed = 2.5f;
        private float walkBackwardsSpeed = 1.5f;

        public override void EnterState(MovementStateManager movementStateManager)
        {
            movementStateManager.GetAnimator().SetBool(WalkAnimationParameter, true);
        }

        public override void UpdateState(MovementStateManager movementStateManager)
        {
            if (movementStateManager.IsInMovement())
            {
                if (GameInput.Instanse.IsRunPressed())
                {
                    ExitState(movementStateManager, movementStateManager.RunningState);
                }
            }
            else
            {
                ExitState(movementStateManager, movementStateManager.IdleState);
            }

            var movementInput = movementStateManager.GetMovementInput();

            // If player goes forwad or aside.
            if (movementInput.y > 0 || Mathf.Abs(movementInput.y) < Mathf.Epsilon)
            {
                movementStateManager.SetMoveSpeed(walkSpeed);
            }
            else
            {
                movementStateManager.SetMoveSpeed(walkBackwardsSpeed);
            }
        }

        private void ExitState(MovementStateManager movementStateManager, MovementBaseState state)
        {
            movementStateManager.GetAnimator().SetBool(WalkAnimationParameter, false);
            movementStateManager.SwitchState(state);
        }
    }
}
