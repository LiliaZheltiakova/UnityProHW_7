using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class GroundCheckComponent : MonoBehaviour, IGroundCheckComponent
    {
        [SerializeField] private GroundCheckMechanic groundMech;
        public bool IsGrounded
        {
            get => this.isGrounded;
            private set => isGrounded = value;
        }

        private bool isGrounded;

        private void FixedUpdate() //combine with one "global" update
        {
            isGrounded = groundMech.IsGrounded();
        }
    }
}

