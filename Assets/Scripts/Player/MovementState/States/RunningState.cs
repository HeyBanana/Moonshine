using Moonshine.Core;
using UnityEngine;

namespace Moonshine.Player.MovementState.States
{
    public class RunningState : MovementBaseState
    {
        private const string RunAnimationParameter = "running";

        public override void EnterState(MovementStateManager movementStateManager)
        {
            movementStateManager.GetAnimator().SetBool(RunAnimationParameter, true);
        }

        public override void UpdateState(MovementStateManager movementStateManager)
        {
            var movementInput = movementStateManager.GetMovementInput();

            // If player goes forward or aside.
            if (movementInput.y > 0 || Mathf.Abs(movementInput.y) < Mathf.Epsilon)
            {
                movementStateManager.SetMoveSpeed(movementStateManager.runSpeed);
            }
            else
            {
                movementStateManager.SetMoveSpeed(movementStateManager.runBackwardsSpeed);
            }

            if (movementStateManager.IsInMovement())
            {
                if (!GameInput.Instanse.IsRunPressed())
                {
                    ExitState(movementStateManager, movementStateManager.WalkingState);
                    return;
                }

                if (GameInput.Instanse.IsJumping())
                {
                    ExitState(movementStateManager, movementStateManager.JumpState);
                    return;
                }
            }
            else
            {
                ExitState(movementStateManager, movementStateManager.IdleState);
            }
        }

        private void ExitState(MovementStateManager movementStateManager, MovementBaseState state)
        {
            movementStateManager.GetAnimator().SetBool(RunAnimationParameter, false);
            movementStateManager.SwitchState(state);
        }
    }
}
