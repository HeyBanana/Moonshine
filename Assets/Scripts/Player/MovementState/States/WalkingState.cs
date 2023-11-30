using Moonshine.Core;

namespace Moonshine.Player.MovementState.States
{
    public class WalkingState : MovementBaseState
    {
        private const string WalkAnimationParameter = "walking";

        private float walkSpeed = 3f;
        private float walkBackwardsSpeed = 2f;

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
            if (movementInput.y > 0)
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
