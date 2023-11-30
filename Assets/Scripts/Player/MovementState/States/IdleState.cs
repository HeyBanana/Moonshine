using Moonshine.Core;

namespace Moonshine.Player.MovementState.States
{
    public class IdleState : MovementBaseState
    {
        public override void EnterState(MovementStateManager movement) { }

        public override void UpdateState(MovementStateManager movementStateManager)
        {
            if (movementStateManager.IsInMovement())
            {
                if (GameInput.Instanse.IsRunPressed())
                {
                    movementStateManager.SwitchState(movementStateManager.RunningState);
                }
                else
                {
                    movementStateManager.SwitchState(movementStateManager.WalkingState);
                }
            }
        }
    }
}
