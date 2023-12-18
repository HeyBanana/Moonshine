using System;
using UnityEngine;

namespace Moonshine.Core
{
    public class GameInput : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;

        public static GameInput Instanse;

        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();

            Instanse = this;
        }

        public Vector2 GetMovementVector()
        {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

            return inputVector;
        }

        public bool IsRunPressed() => playerInputActions.Player.Run.IsPressed();

        public bool IsJumping() => playerInputActions.Player.Jump.IsPressed();
    }
}
