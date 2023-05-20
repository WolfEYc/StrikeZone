using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Animator))]
    public class Toggle : MonoBehaviour
    {

        Animator _animator;
        static readonly int Toggler = Animator.StringToHash("Toggler");
        
        
        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Switch(bool on)
        {
            if (on)
            {
                SetActive();
            }
            _animator.SetTrigger(Toggler);
        }

        public void SetActive()
        {
            gameObject.SetActive(true);
        }

        public void SetInactive()
        {
            gameObject.SetActive(false);
        }
    }
}
