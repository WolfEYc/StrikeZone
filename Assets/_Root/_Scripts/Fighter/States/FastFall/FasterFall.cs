using UnityEngine;

namespace Strikezone
{
    public class FasterFall : MonobehaviorCacher<Movement>
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            
            Cached.FastFall();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            Cached.StopFastFall();
        }
    }
}
