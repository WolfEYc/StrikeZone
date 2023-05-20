using UnityEngine;

namespace Strikezone
{
    public class DashAttackReset : StateMachineBehaviour
    {
        void ResetAttackTriggers(Animator animator)
        {
            animator.ResetTrigger(FighterControls.LightAttackPressedControlID);
            animator.ResetTrigger(FighterControls.HeavyAttackPressedControlID);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            ResetAttackTriggers(animator);
        }
    }
}
