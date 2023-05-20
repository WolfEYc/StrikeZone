using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Gravity : PhysicsUpdater
    {
        Rigidbody2D _rb;
        Vector2 _gravity;
        [SerializeField] float fastFallSpeed;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _gravity = Physics2D.gravity;
        }
        
        public void Reset()
        {
            _gravity = Physics2D.gravity;
        }

        public void FastFall()
        {
            _gravity.y = -fastFallSpeed;
        }

        public override void PhysicsUpdate()
        {
            _rb.velocity += _gravity * Time.fixedDeltaTime;
        }
    }
}
