using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VelocityUpdater : MonoBehaviour
    {
        Rigidbody2D _rb;
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            DebugGraph.Log(_rb.velocity);
        }
    }
}
