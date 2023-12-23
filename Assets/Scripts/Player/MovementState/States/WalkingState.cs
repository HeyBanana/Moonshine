using Moonshine.Core;
using UnityEngine;

namespace Moonshine.Player.MovementState.States
{
    public class WalkingState : MovementBaseState
    {
        private const string WalkAnimationParameter = "walking";

        public override void EnterState(MovementStateManager movementStateManager)
        {
            movementStateManager.GetAnimator().SetBool(WalkAnimationParameter, true);
        }

        public override void UpdateState(MovementStateManager movementStateManager)
        {
            var movementInput = movementStateManager.GetMovementInput();

            // If player goes forward or aside.
            if (movementInput.y > 0 || Mathf.Abs(movementInput.y) < Mathf.Epsilon)
            {
                movementStateManager.SetMoveSpeed(movementStateManager.walkSpeed);
            }
            else
            {
                movementStateManager.SetMoveSpeed(movementStateManager.walkBackwardsSpeed);
            }

            if (movementStateManager.IsInMovement())
            {
                if (GameInput.Instanse.IsRunPressed())
                {
                    ExitState(movementStateManager, movementStateManager.RunningState);
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
            movementStateManager.GetAnimator().SetBool(WalkAnimationParameter, false);
            movementStateManager.SwitchState(state);
        }
    }
}
