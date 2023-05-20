using System;
using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Friction), typeof(VelocityClamping))]
    public class Movement : PhysicsUpdater, IGrounded
    {
        Rigidbody2D _rb;
        Friction _friction;
        Transform _transform;
        VelocityClamping _velocityClamping;
        Gravity _gravity;
        
        [SerializeField] float walkingAccel, runningAccel;
        [SerializeField] float aerialAccel;

        float _accel;

        bool _grounded;
        bool _movementState;
        int _horizontalControls;
        
        void Awake()
        {
            _transform = transform;
            _rb = GetComponent<Rigidbody2D>();
            _friction = GetComponent<Friction>();
            _velocityClamping = GetComponent<VelocityClamping>();
            _gravity = GetComponent<Gravity>();
        }
        
        void EvaluateState()
        {
            enabled = _movementState && _horizontalControls != 0;
            _friction.SetMovementState(!enabled && _grounded);
            _velocityClamping.enabled = _movementState;
            EvaluateSpeedValues();
        }
        
        void EvaluateSpeedValues()
        {
            switch (_grounded)
            {
                case true when Math.Abs(_horizontalControls) <= 1:
                    _accel = walkingAccel;
                    _velocityClamping.ApplyWalkingValues();
                    return;
                case true:
                    _accel = runningAccel;
                    _velocityClamping.ApplyRunningValues();
                    return;
                default:
                    _accel = aerialAccel;
                    _velocityClamping.ApplyFallingValues();
                    return;
            }
        }
        public void SetMovementState(bool movementState)
        {
            _movementState = movementState;
            EvaluateState();
        }
        public void SetControlState(int controlState)
        {
            _horizontalControls = controlState;
            EvaluateState();
        }
        public void SetGrounded(bool grounded)
        {
            _grounded = grounded;
            EvaluateState();
        }
        
        public void FastFall()
        {
            _gravity.FastFall();
            _velocityClamping.ApplyFastFallValues();
        }
        
        public void StopFastFall()
        {
            _gravity.Reset();
            _velocityClamping.RevertFastFallValues();
        }

        public override void PhysicsUpdate()
        {
            _rb.velocity += (Vector2)_transform.right * (Time.fixedDeltaTime * _accel);
        }
    }
}
