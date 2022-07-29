namespace InputSystem
{
    public interface IInputStateManager
    {
        InputLayer CurrentLayer { get; }
        void AddState(InputLayer layer, IInputState state);
        void RemoveLayer(InputLayer layer, IInputState state);
        void ChangeLayer(InputLayer layer);

    }
}