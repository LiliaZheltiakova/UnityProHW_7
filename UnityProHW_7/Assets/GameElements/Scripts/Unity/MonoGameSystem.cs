using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameElements.Unity
{
    [AddComponentMenu("GameElements/Game System")]
    [DisallowMultipleComponent]
    public class MonoGameSystem : MonoBehaviour, IGameSystem
    {
        public event Action OnLoaded;

        public bool IsAutoRun
        {
            get { return this.autoRun; }
        }

        [SerializeField]
        private bool autoRun = true;

        private bool isLoaded;

        [Space]
        [SerializeField]
        private List<MonoBehaviour> gameServices = new List<MonoBehaviour>();

        [Space]
        [SerializeField]
        private List<MonoBehaviour> gameElements = new List<MonoBehaviour>();

        public event Action OnGameInitialized
        {
            add { this.gameSystem.OnGameInitialized += value; }
            remove { this.gameSystem.OnGameInitialized -= value; }
        }

        public event Action OnGameReady
        {
            add { this.gameSystem.OnGameReady += value; }
            remove { this.gameSystem.OnGameReady -= value; }
        }

        public event Action OnGameStarted
        {
            add { this.gameSystem.OnGameStarted += value; }
            remove { this.gameSystem.OnGameStarted -= value; }
        }

        public event Action OnGamePaused
        {
            add { this.gameSystem.OnGamePaused += value; }
            remove { this.gameSystem.OnGameResumed -= value; }
        }

        public event Action OnGameResumed
        {
            add { this.gameSystem.OnGameResumed += value; }
            remove { this.gameSystem.OnGameResumed -= value; }
        }

        public event Action OnGameFinished
        {
            add { this.gameSystem.OnGameFinished += value; }
            remove { this.gameSystem.OnGameFinished -= value; }
        }

        public GameState State
        {
            get { return this.gameSystem.State; }
        }

        private readonly IGameSystem gameSystem;

        public MonoGameSystem()
        {
            this.gameSystem = new GameSystem();
        }

        public void LoadGame()
        {
            if (this.isLoaded)
            {
                Debug.LogWarning("Game is already loaded!");
                return;
            }

            this.LoadServices();
            this.LoadGameElements();
            this.isLoaded = true;
            this.OnLoaded?.Invoke();
        }

        public void InitGame()
        {
            this.gameSystem.InitGame();
        }

        public void ReadyGame()
        {
            this.gameSystem.ReadyGame();
        }

        public void StartGame()
        {
            this.gameSystem.StartGame();
        }

        public void PauseGame()
        {
            this.gameSystem.PauseGame();
        }

        public void ResumeGame()
        {
            this.gameSystem.ResumeGame();
        }

        public void FinishGame()
        {
            this.gameSystem.FinishGame();
        }

        public void AddElement(object element)
        {
            this.gameSystem.AddElement(element);
        }

        public void RemoveElement(object element)
        {
            this.gameSystem.RemoveElement(element);
        }

        public void AddService(object service)
        {
            this.gameSystem.AddService(service);
        }

        public void RemoveService(object service)
        {
            this.gameSystem.RemoveService(service);
        }

        public T GetService<T>()
        {
            return this.gameSystem.GetService<T>();
        }

        public bool TryGetService<T>(out T service)
        {
            return this.gameSystem.TryGetService(out service);
        }

        private IEnumerator Start()
        {
            if (this.autoRun)
            {
                yield return new WaitForEndOfFrame();
                this.LoadGame();
                this.InitGame();
                this.ReadyGame();
                this.StartGame();
            }
        }

        private void LoadGameElements()
        {
            for (int i = 0, count = this.gameElements.Count; i < count; i++)
            {
                var monoElement = this.gameElements[i];
                if (monoElement is IGameElement gameElement)
                {
                    this.AddElement(gameElement);
                }
            }
        }

        private void LoadServices()
        {
            for (int i = 0, count = this.gameServices.Count; i < count; i++)
            {
                var monoService = this.gameServices[i];
                if (monoService != null)
                {
                    this.AddService(monoService);
                }
            }
        }

#if UNITY_EDITOR
        public void Editor_AddElement(IGameElement gameElement)
        {
            this.gameElements.Add((MonoBehaviour) gameElement);
        }

        public void Editor_AddService(MonoBehaviour gameService)
        {
            this.gameServices.Add(gameService);
        }

        private void OnValidate()
        {
            MonoGameValidator.ValidateGameServices(ref this.gameServices);
            MonoGameValidator.ValidateGameElements(ref this.gameElements);
        }
#endif
    }
}