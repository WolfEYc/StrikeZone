using UnityEngine;

namespace Strikezone
{
    public class SetInactiveOnEnter : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            animator.gameObject.SetActive(false);
        }
    }
}
