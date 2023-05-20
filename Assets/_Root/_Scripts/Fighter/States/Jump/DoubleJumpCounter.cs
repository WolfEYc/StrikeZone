using UnityEngine;

namespace Strikezone
{
	public class DoubleJumpCounter : StateMachineBehaviour
	{
		public static readonly int DoubleJumpID = Animator.StringToHash("double_jump_counter");


		int GetCounter(Animator animator)
		{
			return animator.GetInteger(DoubleJumpID);
		}
		
		void IncrementCounter(Animator animator)
		{
			animator.SetInteger(DoubleJumpID, GetCounter(animator) + 1);
		}
		

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateEnter(animator, stateInfo, layerIndex);
			IncrementCounter(animator);
		}
	}
}
