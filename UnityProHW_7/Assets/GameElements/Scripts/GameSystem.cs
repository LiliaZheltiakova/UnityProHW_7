using System;

namespace GameElements
{
    public class GameSystem : IGameSystem
    {
        public event Action OnGameInitialized;

        public event Action OnGameReady;

        public event Action OnGameStarted;

        public event Action OnGamePaused;

        public event Action OnGameResumed;

        public event Action OnGameFinished;

        public GameState State { get; protected set; }

        private readonly GameElementContext elementContext;

        private readonly GameServiceContext serviceContext;

        public GameSystem()
        {
            this.State = GameState.NOT_INITITALIZED;
            this.elementContext = new GameElementContext(this);
            this.serviceContext = new GameServiceContext();
        }

        public void InitGame()
        {
            if (this.State != GameState.NOT_INITITALIZED)
            {
                throw new Exception($"Can't initialize the game from the {this.State} state, " +
                                    $"only from {nameof(GameState.NOT_INITITALIZED)}");
            }

            this.OnInitGame();
            this.State = GameState.INITIALIZED;
            this.elementContext.InitGame();
            this.OnGameInitialized?.Invoke();
        }

        protected virtual void OnInitGame()
        {
        }

        public void ReadyGame()
        {
            if (this.State != GameState.INITIALIZED)
            {
                throw new Exception($"Can't set ready the game from the {this.State} state, " +
                                    $"only from {nameof(GameState.INITIALIZED)}");
            }

            this.OnReadyGame();
            this.State = GameState.READY;
            this.elementContext.ReadyGame();
            this.OnGameReady?.Invoke();
        }

        protected virtual void OnReadyGame()
        {
        }

        public void StartGame()
        {
            if (this.State != GameState.READY)
            {
                throw new Exception($"Can't start the game from the {this.State} state, " +
                                    $"only from {nameof(GameState.READY)}");
            }

            this.OnStartGame();
            this.State = GameState.PLAYING;
            this.elementContext.StartGame();
            this.OnGameStarted?.Invoke();
        }

        protected virtual void OnStartGame()
        {
        }

        public void PauseGame()
        {
            if (this.State != GameState.PLAYING)
            {
                throw new Exception($"Can't pause the game from the {this.State} state, " +
                                    $"only from {nameof(GameState.PLAYING)}");
            }

            this.OnPauseGame();
            this.State = GameState.PAUSED;
            this.elementContext.PauseGame();
            this.OnGamePaused?.Invoke();
        }

        protected virtual void OnPauseGame()
        {
        }

        public void ResumeGame()
        {
            if (this.State != GameState.PAUSED)
            {
                throw new Exception($"Can't resume the game from the {this.State} state, " +
                                    $"only from {nameof(GameState.PAUSED)}");
            }

            this.OnResumeGame();
            this.State = GameState.PLAYING;
            this.elementContext.ResumeGame();
            this.OnGameResumed?.Invoke();
        }

        protected virtual void OnResumeGame()
        {
        }

        public void FinishGame()
        {
            if (this.State == GameState.PLAYING || this.State == GameState.PAUSED)
            {
                this.OnFinishGame();
                this.State = GameState.FINISHED;
                this.elementContext.FinishGame();
                this.OnGameFinished?.Invoke();
            }
            else
            {
                throw new Exception($"Can't finish the game from the {this.State} state, " +
                                    $"only from {nameof(GameState.PLAYING)} or {nameof(GameState.PAUSED)}");
            }
        }

        protected virtual void OnFinishGame()
        {
        }

        public void AddElement(object element)
        {
            if (element is IGameElement gameElement)
            {
                this.elementContext.AddElement(gameElement);
            }
        }

        public void RemoveElement(object element)
        {
            if (element is IGameElement gameElement)
            {
                this.elementContext.RemoveElement(gameElement);
            }
        }

        public void AddService(object service)
        {
            this.serviceContext.AddService(service);
        }

        public void RemoveService(object service)
        {
            this.serviceContext.RemoveService(service);
        }

        public T GetService<T>()
        {
            return this.serviceContext.GetService<T>();
        }

        public bool TryGetService<T>(out T service)
        {
            return this.serviceContext.TryGetService(out service);
        }
    }
}