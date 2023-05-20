using UnityEngine;

namespace Strikezone
{
    public class ParryState : MonobehaviorCacher<DamagableFighter>
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            Cached.Invincible = true;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            Cached.Invincible = false;
        }
    }
}
