namespace InputSystem
{
    public interface IInputState // ? merge with StateMachine.State ?
    {
        void EnterState();
        void ExitState();
        void UpdateState(float deltaTime);
    }
}