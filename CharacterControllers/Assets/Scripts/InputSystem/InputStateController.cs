using UnityEngine;
using GameS;

namespace InputSystem
{
    public class InputStateController : MonoBehaviour,
        IGameInitComponent,
        IGameStartComponent,
        IGameFinishComponent
    {
        private InputStateMachine inputStateManager;
        private IPauseInput keyboard;

        public void OnInitGame(IGameSystem system)
        {
            this.inputStateManager = system.GetService<InputStateMachine>();
            this.keyboard = system.GetService<IPauseInput>();
        }

        void IGameStartComponent.OnStartGame(IGameSystem system)
        {
            
            this.inputStateManager.enabled = true;
            this.keyboard.OnPauseInputPressed += ChangeMode;
        }

        public void OnFinishGame()
        {
            this.inputStateManager.enabled = false;
            this.keyboard.OnPauseInputPressed -= ChangeMode;
        }

        private void ChangeMode()
        {
            if(this.inputStateManager.CurrentState == InputStateEnum.BASE)
            {
                this.inputStateManager.ChangeState(InputStateEnum.PAUSE);
            }

            else
            {
                this.inputStateManager.ChangeState(InputStateEnum.BASE);
            }
        }
    }
}