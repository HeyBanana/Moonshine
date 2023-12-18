using Moonshine.Core;
using Moonshine.Player.MovementState.States;
using UnityEngine;

namespace Moonshine.Player.MovementState
{
    public class MovementStateManager : MonoBehaviour
    {
        private const string HorizontalMovementAnimationParameter = "horizontalInput";
        private const string VerticalMovementAnimationParameter = "verticalInput";

        [SerializeField] private GameInput gameInput;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;

        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private float jumpHeight = 5f;

        [SerializeField] private float animationTransitionSpeed = 10f;

        private float moveSpeed = 3f;
        private float movementY;

        // Vector2 that received from keyboard.
        private Vector2 inputVector;
        private Vector3 movementVector;

        private MovementBaseState currentMovementState;

        public IdleState IdleState = new IdleState();
        public WalkingState WalkingState = new WalkingState();
        public RunningState RunningState = new RunningState();
        public JumpState JumpState = new JumpState();

        public Vector3 GetMovementVector() => movementVector;
        public Vector2 GetMovementInput() => inputVector;
        public Animator GetAnimator() => animator;
        public float GetGravity() => gravity;
        public float GetJumpHeight() => jumpHeight;
        public float GetGroundedGravity() => -0.5f;

        public void SetMoveSpeed(float value)
        {
            moveSpeed = value;
        }

        public void SetMovementY(float value)
        {
            movementY = value;
        }

        private void Start()
        {
            SwitchState(IdleState);

            movementY = GetGroundedGravity();
        }

        private void FixedUpdate()
        {
            inputVector = gameInput.GetMovementVector();

            var moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

            currentMovementState.UpdateState(this);

            movementVector = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
            movementVector.y = movementY;

            characterController.Move(movementVector);

            HandleAnimations();
        }

        private void HandleAnimations()
        {
            var currentHorizontalValue = animator.GetFloat(HorizontalMovementAnimationParameter);
            var currentVerticalValue = animator.GetFloat(VerticalMovementAnimationParameter);

            var horizontalValue = Mathf.Lerp(currentHorizontalValue, inputVector.x, Time.fixedDeltaTime * animationTransitionSpeed);
            var verticalValue = Mathf.Lerp(currentVerticalValue, inputVector.y, Time.fixedDeltaTime * animationTransitionSpeed);

            animator.SetFloat(HorizontalMovementAnimationParameter, horizontalValue);
            animator.SetFloat(VerticalMovementAnimationParameter, verticalValue);
        }

        public void SwitchState(MovementBaseState state)
        {
            currentMovementState = state;
            currentMovementState.EnterState(this);
        }

        public bool IsInMovement()
        {
            return inputVector != Vector2.zero;
        }

        public bool IsGrounded()
        {
            return characterController.isGrounded;
        }

        #region Animation Events

        public bool AnimationJumpStarted { get; private set; }
        public bool JustLanded { get; private set; }

        public void StartAnimatedJump()
        {
            AnimationJumpStarted = true;
        }

        public void SetLandedState()
        {
            JustLanded = true;
        }

        public void ResetAnimationEventsState()
        {
            AnimationJumpStarted = false;
            JustLanded = false;
        }

        #endregion
    }
}
