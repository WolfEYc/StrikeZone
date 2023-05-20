using UnityEngine;

namespace Strikezone
{
    public class PerformJumpOnEnter : MonobehaviorCacher<Jump>
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            Cached.PerformJump();
        }
    }
}
