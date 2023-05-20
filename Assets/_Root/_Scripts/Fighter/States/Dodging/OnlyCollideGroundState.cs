using UnityEngine;

namespace Strikezone
{
    public class OnlyCollideGroundState : StateMachineBehaviour
    {
        static readonly int GroundCheck = 14;
        int _previousLayer;

        void OnlyCollideGround(Animator animator)
        {
            GameObject gameObject = animator.gameObject;
            _previousLayer = gameObject.layer;
            gameObject.layer = GroundCheck;
        }

        void CollideNormal(Animator animator)
        {
            animator.gameObject.layer = _previousLayer;
        }
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            OnlyCollideGround(animator);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            CollideNormal(animator);
        }
    }
}
