using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Movement), typeof(Rigidbody2D))]
    public class VelocityClamping : PhysicsUpdater
    {
        Rigidbody2D _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            ApplyDefaultValues();
        }

        [SerializeField] float maxWalkSpeed, maxRunSpeed, maxAerialSpeed;
        [SerializeField] float maxFallSpeed, maxFastFallSpeed;
        [SerializeField] float maxUpwardsSpeed;

        Vector2 _maxVel, _minVel;

        void ApplyDefaultValues()
        {
            ApplyFallingValues();
            _maxVel.y = maxUpwardsSpeed;
            _minVel.y = -maxFallSpeed;
        }
        
        public void ApplyWalkingValues()
        {
            _minVel.x = -maxWalkSpeed;
            _maxVel.x = maxWalkSpeed;
        }

        public void ApplyRunningValues()
        {
            _minVel.x = -maxRunSpeed;
            _maxVel.x = maxRunSpeed;
        }

        public void ApplyFallingValues()
        {
            _maxVel.x = maxAerialSpeed;
            _minVel.x = -maxAerialSpeed;
        }

        public void ApplyFastFallValues()
        {
            _minVel.y = -maxFastFallSpeed;
        }

        public void RevertFastFallValues()
        {
            _minVel.y = -maxFallSpeed;
        }

        void ClampVelocity()
        {
            var velocity = _rb.velocity;
            velocity.x = Mathf.Clamp(velocity.x, _minVel.x, _maxVel.x);
            velocity.y = Mathf.Clamp(velocity.y, _minVel.y, _maxVel.y);
            _rb.velocity = velocity;
        }
        public override void PhysicsUpdate()
        {
            ClampVelocity();
        }
    }
}
