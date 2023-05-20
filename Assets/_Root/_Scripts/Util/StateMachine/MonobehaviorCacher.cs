using UnityEngine;

namespace Strikezone
{
    public class MonobehaviorCacher<T> : StateMachineBehaviour where T : MonoBehaviour
    {
        protected T Cached { get; private set; }
        bool _cached;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            CacheBehaviour(animator);
        }
        
        void CacheBehaviour(Animator animator)
        {
            if (_cached) return;
            
            Cached = animator.GetComponent<T>();
            _cached = true;
        }
    }
}
