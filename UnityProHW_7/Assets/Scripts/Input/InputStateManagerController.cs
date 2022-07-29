using GameElements;
using UnityEngine;

namespace InputSystem
{
    public class InputStateManagerController : MonoBehaviour, IGameStartElement, IGameFinishElement
    {
        private InputStateManager stateManager;
        
        void IGameStartElement.StartGame(IGameSystem system)
        {
            this.stateManager = system.GetService<InputStateManager>();
            this.stateManager.enabled = true;
        }
        
        void IGameFinishElement.FinishGame(IGameSystem system)
        {
            this.stateManager.enabled = false;
        }
    }
}