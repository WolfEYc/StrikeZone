using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Rigidbody2D), typeof(FighterControls))]
    public class Dodge : PhysicsUpdater
    {
        [SerializeField] float dodgeForce;

        Rigidbody2D _rb;
        FighterControls _fighterControls;
        Friction _friction;
        Facing _facing;
        GroundCheck _groundCheck;
        Transform _transform;
        Gravity _gravity;
        Hurtbox _hurtbox;
        

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _fighterControls = GetComponent<FighterControls>();
            _groundCheck = GetComponentInChildren<GroundCheck>();
            _gravity = GetComponent<Gravity>();
            _friction = GetComponent<Friction>();
            _facing = GetComponent<Facing>();
            _hurtbox = GetComponent<Hurtbox>();
            _transform = transform;
            enabled = false;
        }

        public void PerformDodge()
        {
            enabled = true;
            _hurtbox.enabled = false;
        }

        Vector2 Dir()
        {
            if (_groundCheck.Grounded) return _transform.right;
            return _fighterControls.MoveCtrls.normalized;
        }

        public override void PhysicsUpdate()
        {
            _rb.velocity = Dir() * dodgeForce;
            _rb.OrientAlongVelocity();
            _facing.enabled = false;
            _friction.SetFrictionState(false);
            _gravity.enabled = false;
            enabled = false;
        }

        public void EndDodge()
        {
            _rb.rotation = 0f;
            _rb.velocity = Vector2.zero;
            _facing.enabled = true;
            _gravity.enabled = true;
            _friction.SetFrictionState(true);
            _hurtbox.enabled = true;
        }
    }
}
