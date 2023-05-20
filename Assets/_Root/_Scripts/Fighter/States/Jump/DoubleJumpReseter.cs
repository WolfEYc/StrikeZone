using UnityEngine;

namespace Strikezone
{
    public class DoubleJumpReseter : StateMachineBehaviour
    {
        void ResetCounter(Animator animator)
        {
            animator.SetInteger(DoubleJumpCounter.DoubleJumpID, 0);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            ResetCounter(animator);
            animator.ResetTrigger(FighterControls.JumpPressedControlID);
            animator.ResetTrigger(FighterControls.DodgeControlID);
        }
    }
}
