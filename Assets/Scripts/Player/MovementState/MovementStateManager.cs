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
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private Animator animator;

        private float moveSpeed = 3f;

        public void SetMoveSpeed(float value)
        {
            moveSpeed = value;
        }

        public Animator GetAnimator() => animator;

        // Vector2 that received from keyboard.
        private Vector2 inputVector;

        public Vector2 GetMovementInput() => inputVector;

        private Vector3 movementVector;

        private MovementBaseState currentMovementState;

        public IdleState IdleState = new IdleState();
        public WalkingState WalkingState = new WalkingState();
        public RunningState RunningState = new RunningState();

        private void Start()
        {
            SwitchState(IdleState);
        }

        private void FixedUpdate()
        {
            inputVector = gameInput.GetMovementVector();

            var moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

            movementVector = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
            movementVector.y = GetGravityValue();

            characterController.Move(movementVector);

            currentMovementState.UpdateState(this);

            HandleAnimations();
        }

        private void HandleAnimations()
        {
            animator.SetFloat(HorizontalMovementAnimationParameter, inputVector.x);
            animator.SetFloat(VerticalMovementAnimationParameter, inputVector.y);
        }

        public void SwitchState(MovementBaseState state)
        {
            currentMovementState = state;
            currentMovementState.EnterState(this);
        }

        private float GetGravityValue()
        {
            return characterController.isGrounded ? 0f : gravity;
        }

        public bool IsInMovement()
        {
            return inputVector != Vector2.zero;
        }
    }
}
