namespace Moonshine.Player.MovementState
{
    public abstract class MovementBaseState
    {
        public abstract void EnterState(MovementStateManager movementStateManager);
        public abstract void UpdateState(MovementStateManager movementStateManager);
    }
}
