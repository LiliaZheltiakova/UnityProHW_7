using UnityEngine;

namespace Homework
{
    public class PlayerMoveState : State
    {
        [SerializeField] private MoveMechanic moveMech;
        [SerializeField] private Rigidbody2D rigidBody;
        
        private void FixedUpdate()
        {
            if (moveMech.IsMoving)
            {
                Move();
            }
        }

        private void Move()
        {
            var direction = this.moveMech.Direction;
            float scaleX = rigidBody.gameObject.transform.localScale.x;
            rigidBody.velocity = new Vector2(direction.x, direction.y);
            
            if (scaleX != direction.x)
            {
                rigidBody.gameObject.transform.localScale = new Vector3(direction.x, 1f, 1f);
            }
        }
    }
}