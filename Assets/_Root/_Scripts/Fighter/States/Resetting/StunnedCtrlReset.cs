using UnityEngine;

namespace Strikezone
{
    public class StunnedCtrlReset : StateMachineBehaviour
    {
        void ResetTriggers(Animator animator)
        {
            animator.ResetTrigger(FighterControls.LightAttackPressedControlID);
            animator.ResetTrigger(FighterControls.HeavyAttackPressedControlID);
            animator.ResetTrigger(FighterControls.SpecialPressedControlID);

            animator.ResetTrigger(FighterControls.AttackPressedControlID);
            
            
            animator.ResetTrigger(FighterControls.DodgeControlID);
            
            animator.ResetTrigger(FighterControls.JumpPressedControlID);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            ResetTriggers(animator);
        }
    }
}
