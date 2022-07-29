using System.Collections.Generic;

namespace GameElements
{
    public interface IGameElement
    {
    }

    public interface IGameEnableElement : IGameElement
    {
        bool IsEnable { get; }
    }

    public interface IGameReferenceElement : IGameElement
    {
        IGameSystem GameSystem { set; }
    }

    public interface IGameElementGroup : IGameElement
    {
        IEnumerable<IGameElement> GetElements();
    }

    public interface IGameInitElement : IGameElement
    {
        void InitGame(IGameSystem system);
    }

    public interface IGameReadyElement : IGameElement
    {
        void ReadyGame(IGameSystem system);
    }

    public interface IGameStartElement : IGameElement
    {
        void StartGame(IGameSystem system);
    }

    public interface IGamePauseElement : IGameElement
    {
        void PauseGame(IGameSystem system);
    }

    public interface IGameResumeElement : IGameElement
    {
        void ResumeGame(IGameSystem system);
    }

    public interface IGameFinishElement : IGameElement
    {
        void FinishGame(IGameSystem system);
    }
}