using UnityEngine;

namespace Gameplay
{
    public class Component_Jump : MonoBehaviour, IComponent_Jump

    {
        [SerializeField] private JumpMechanic jumpMechanic;
        public void JumpUp()
        {
            this.jumpMechanic.JumpUp();
        }

        public void JumpDown()
        {
            this.jumpMechanic.JumpDown();
        }
    }
}