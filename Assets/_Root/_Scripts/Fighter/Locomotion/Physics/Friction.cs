using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Friction : PhysicsUpdater
    {
        [SerializeField] float groundedFriction;
        [SerializeField] float threshold;
        
        Rigidbody2D _rb;
            

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public override void PhysicsUpdate()
        {
            var velocity = _rb.velocity;
            velocity -= velocity.normalized * (groundedFriction * Time.fixedDeltaTime);
            
            _rb.velocity = velocity;
            
            if(Mathf.Abs(velocity.sqrMagnitude) > threshold) return;
            
            _rb.velocity = Vector2.zero;
        }

        bool _movementState = true;
        bool _frictionState = true;


        public void SetMovementState(bool movementState)
        {
            _movementState = movementState;
            TryEnable();
        }

        public void SetFrictionState(bool fricState)
        {
            _frictionState = fricState;
            TryEnable();
        }

        void TryEnable()
        {
            enabled = _movementState && _frictionState;
        }
        
    }
}
