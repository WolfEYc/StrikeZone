using UnityEngine;

namespace Strikezone
{
    public class PlayOnEnter : StateMachineBehaviour
    {
        [SerializeField] AudioClip clip;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            AudioManager.Instance.PlaySound(clip);
        }
    }
}
