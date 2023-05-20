using UnityEngine;

namespace Strikezone
{
    public class Facing : MonoBehaviour
    {
        Transform _transform;

        static readonly Vector3 LeftFacing = new(0, 180, 0);
        
        bool _facingRight = true;

        void Awake()
        {
            _transform = transform;
        }

        public void SetFacing(bool right)
        {
            if(right == _facingRight) return;
            _facingRight = right;
            
            ApplyFacing();
        }

        public void ApplyFacing()
        {
            if(!enabled) return;
            _transform.eulerAngles = _facingRight ? Vector3.zero : LeftFacing;
        }

        void OnEnable()
        {
            ApplyFacing();
        }
    }
}
