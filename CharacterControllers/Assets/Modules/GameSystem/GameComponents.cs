namespace GameS
{
    public interface IGameInitComponent
    {
        void OnInitGame(IGameSystem system);
    }
    public interface IGameReadyComponent
    {
        void OnReadyGame(IGameSystem system);
    }
    public interface IGameStartComponent
    {
        void OnStartGame(IGameSystem system);
    }
    public interface IGamePauseComponent
    {
        void OnPauseGame();
    }
    public interface IGameResumeComponent
    {
        void OnResumeGame();
    }
    public interface IGameFinishComponent
    {
        void OnFinishGame();
    }
}