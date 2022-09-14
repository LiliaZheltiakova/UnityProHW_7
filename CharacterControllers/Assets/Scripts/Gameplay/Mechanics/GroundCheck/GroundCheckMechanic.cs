using UnityEngine;

namespace Gameplay
{
    public class GroundCheckMechanic : MonoBehaviour
    {
        [SerializeField] private Transform groundChecker;
        [SerializeField] private float checkRadius;
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private bool isGrounded;

        public bool IsGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(groundChecker.position, checkRadius, whatIsGround);
            return isGrounded;
        }
    }
}