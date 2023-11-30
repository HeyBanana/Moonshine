using Moonshine.Core;

namespace Moonshine.Player.MovementState.States
{
    public class RunningState : MovementBaseState
    {
        private const string RunAnimationParameter = "running";

        private float runSpeed = 6f;
        private float runBackwardsSpeed = 4f;

        public override void EnterState(MovementStateManager movementStateManager)
        {
            movementStateManager.GetAnimator().SetBool(RunAnimationParameter, true);
        }

        public override void UpdateState(MovementStateManager movementStateManager)
        {
            if (movementStateManager.IsInMovement())
            {
                if (GameInput.Instanse.IsRunReleased())
                {
                    ExitState(movementStateManager, movementStateManager.WalkingState);
                }
            }
            else
            {
                ExitState(movementStateManager, movementStateManager.IdleState);
            }

            var movementInput = movementStateManager.GetMovementInput();
            if (movementInput.y > 0)
            {
                movementStateManager.SetMoveSpeed(runSpeed);
            }
            else
            {
                movementStateManager.SetMoveSpeed(runBackwardsSpeed);
            }
        }

        private void ExitState(MovementStateManager movementStateManager, MovementBaseState state)
        {
            movementStateManager.GetAnimator().SetBool(RunAnimationParameter, false);
            movementStateManager.SwitchState(state);
        }
    }
}
