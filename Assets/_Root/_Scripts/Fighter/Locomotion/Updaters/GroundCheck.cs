using UnityEngine;

namespace Strikezone
{
    public class GroundCheck : MonoBehaviour
    {
        static readonly int GroundedID = Animator.StringToHash("grounded");
        
        [SerializeField] Animator animator;
        IGrounded[] _whoCares;
        public bool Grounded { get; private set; }

        void Awake()
        {
            _whoCares = animator.GetComponentsInChildren<IGrounded>();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            animator.SetBool(GroundedID, true);
            foreach (IGrounded guyWhoCares in _whoCares)
            {
                guyWhoCares.SetGrounded(true);   
            }

            Grounded = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            animator.SetBool(GroundedID, false);
            foreach (IGrounded guyWhoCares in _whoCares)
            {
                guyWhoCares.SetGrounded(false);   
            }

            Grounded = false;
        }
    }
}
