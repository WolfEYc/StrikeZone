using UnityEngine;

namespace Strikezone
{
    public class ChangeSceneOnExit : StateMachineBehaviour
    {
        [SerializeField] int buildIndex;
    
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            SceneMaster.Instance.LoadScene(buildIndex);
        }
    }
}
