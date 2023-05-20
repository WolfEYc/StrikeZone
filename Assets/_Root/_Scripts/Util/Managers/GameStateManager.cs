using UnityEngine;

namespace Strikezone
{
    public class GameStateManager : MonoBehaviour
    {
        Animator _stateMachine;

        void Awake()
        {
            _stateMachine = GetComponent<Animator>();
        }
    
    
    
    }
}
