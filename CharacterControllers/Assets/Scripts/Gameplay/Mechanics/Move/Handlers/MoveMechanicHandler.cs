using UnityEngine;

namespace Gameplay
{
    public class MoveMechanicHandler : MonoBehaviour
    {
        [SerializeField] private MoveMechanic moveMechanic;

        private void OnEnable()
        {
            this.moveMechanic.OnStartMove += this.OnStartMove;
            this.moveMechanic.OnFinishMove += this.OnFinishMove;
        }

        private void OnDisable()
        {
            this.moveMechanic.OnStartMove -= this.OnStartMove;
            this.moveMechanic.OnFinishMove -= this.OnFinishMove;
        }

        protected virtual void OnStartMove() { }


        protected virtual void OnFinishMove() { }
    }
}