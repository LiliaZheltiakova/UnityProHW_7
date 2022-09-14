using UnityEngine;

namespace Gameplay
{
    public class JumpComponent : MonoBehaviour, IJumpComponent

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