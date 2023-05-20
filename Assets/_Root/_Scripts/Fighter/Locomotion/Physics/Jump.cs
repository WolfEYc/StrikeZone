using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : PhysicsUpdater
    {
        [SerializeField] float jumpForce;
        Rigidbody2D _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            enabled = false;
        }

        public void PerformJump()
        {
            enabled = true;
        }
        
        public override void PhysicsUpdate()
        {
            _rb.velocity = jumpForce * Vector2.up;
            enabled = false;
        }
    }
}
