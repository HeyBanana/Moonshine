using UnityEngine;

namespace Moonshine.Player.MovementState.States
{
    public class JumpState : MovementBaseState
    {
        private const string JumpingAnimationParameter = "jumping";
        private const string FallingAnimationParameter = "falling";
        private const string LandingAnimationParameter = "landing";

        private const float AirMovementSpeed = 3f;

        private bool jumpForceAdded;
        private bool inFallingState;

        private float jumpVelocity;

        public override void EnterState(MovementStateManager movementStateManager)
        {
            movementStateManager.GetAnimator().SetTrigger(JumpingAnimationParameter);
            movementStateManager.GetAnimator().ResetTrigger(FallingAnimationParameter);
            movementStateManager.GetAnimator().SetBool(LandingAnimationParameter, false);

            jumpForceAdded = false;
            inFallingState = false;

            movementStateManager.ResetAnimationEventsState();

            movementStateManager.SetMoveSpeed(0);
        }

        public override void UpdateState(MovementStateManager movementStateManager)
        {
            if (movementStateManager.AnimationJumpStarted && !jumpForceAdded)
            {
                jumpVelocity = Mathf.Sqrt(movementStateManager.GetJumpHeight() * -2 * (movementStateManager.GetGravity()));
                jumpForceAdded = true;
            }

            if (jumpForceAdded && !movementStateManager.IsGrounded())
            {
                jumpVelocity += movementStateManager.GetGravity() * Time.fixedDeltaTime;
                movementStateManager.SetMoveSpeed(AirMovementSpeed);
            }

            if (jumpVelocity < 0 && jumpForceAdded && !inFallingState)
            {
                movementStateManager.GetAnimator().SetTrigger(FallingAnimationParameter);
                inFallingState = true;
            }

            movementStateManager.SetMovementY(jumpVelocity * Time.fixedDeltaTime);

            if (movementStateManager.IsGrounded() && inFallingState)
            {
                movementStateManager.SetMovementY(movementStateManager.GetGroundedGravity());
                movementStateManager.SetMoveSpeed(0);

                movementStateManager.GetAnimator().SetBool(LandingAnimationParameter, true);

                if (movementStateManager.JustLanded)
                {
                    movementStateManager.GetAnimator().SetBool(LandingAnimationParameter, false);
                    movementStateManager.SwitchState(movementStateManager.IdleState);
                }
            }
        }
    }
}
