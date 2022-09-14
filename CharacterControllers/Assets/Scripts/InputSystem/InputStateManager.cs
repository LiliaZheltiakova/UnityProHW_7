using UnityEngine;
using GameS;

namespace InputSystem
{
    public class InputStateManager : MonoBehaviour,
        IGameInitComponent,
        IGameStartComponent,
        IGameFinishComponent
    {
        private InputStateMachine inputStateManager;
        private IKeyboardESCInput keyboard;

        public void OnInitGame(IGameSystem system)
        {
            this.inputStateManager = system.GetService<InputStateMachine>();
            this.keyboard = system.GetService<IKeyboardESCInput>();
        }

        void IGameStartComponent.OnStartGame(IGameSystem system)
        {
            
            this.inputStateManager.enabled = true;
            this.keyboard.OnESCPressed += ChangeMode;
        }

        public void OnFinishGame()
        {
            this.inputStateManager.enabled = false;
            this.keyboard.OnESCPressed -= ChangeMode;
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