using UnityEngine;

namespace Strikezone
{
    public class PerformDodgeOnEnter : MonobehaviorCacher<Dodge>
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            animator.SetInteger(DoubleJumpCounter.DoubleJumpID, 2);
            Cached.PerformDodge();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            Cached.EndDodge();
        }
    }
}
