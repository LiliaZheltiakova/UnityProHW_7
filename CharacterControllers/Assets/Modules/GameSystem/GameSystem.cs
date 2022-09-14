using System;
using System.Collections;
using UnityEngine;

namespace GameS
{
    public class GameSystem : MonoBehaviour, IGameSystem
    {
        [SerializeField] private MonoBehaviour[] components;
        [SerializeField] private bool isAutoRun = true;

        private IEnumerator Start()
        {
            if (this.isAutoRun)
            {
                yield return null;
                this.Run();
            }
            yield break;
        }

        private void Run()
        {
            this.InitGame();
            this.StartGame();
            this.ReadyGame();
        }

        public void InitGame()
        {
            foreach (var component in this.components)
            {
                if (component is IGameInitComponent initComponent)
                {
                    initComponent.OnInitGame(this);
                }
            }
        }

        public void StartGame()
        {
            foreach (var component in this.components)
            {
                if (component is IGameStartComponent startComponent)
                {
                    startComponent.OnStartGame(this);
                }
            }
        }

        public void ReadyGame()
        {
            foreach(var component in this.components)
            {
                if(component is IGameReadyComponent readyComponent)
                {
                    readyComponent.OnReadyGame(this);
                }
            }
        }
        public void PauseGame()
        {
            foreach (var component in this.components)
            {
                if (component is IGamePauseComponent pauseComponent)
                {
                    pauseComponent.OnPauseGame();
                }
            }
        }
        public void ResumeGame()
        {
            foreach (var component in this.components)
            {
                if (component is IGameResumeComponent resumeComponent)
                {
                    resumeComponent.OnResumeGame();
                }
            }
        }

        public void FinishGame()
        {
            foreach (var component in this.components)
            {
                if (component is IGameFinishComponent finishComponent)
                {
                    finishComponent.OnFinishGame();
                }
            }
        }

        public T GetService<T>()
        {
            foreach (var component in components)
            {
                if (component is T tComponent)
                    return tComponent;
            }

            throw new Exception($"Component {typeof(T).Name} is not found");
        }
    }
}