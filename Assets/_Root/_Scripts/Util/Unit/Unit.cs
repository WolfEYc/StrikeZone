using UnityEngine;

namespace Strikezone
{
    public abstract class Unit : MonoBehaviour
    {
        protected Animator StateMachine;
        public Transform InstanceTransform { get; private set; }
        public GameObject InstanceGameobject { get; private set; }
        
        
        protected virtual void Awake()
        {
            InstanceTransform = transform;
            InstanceGameobject = gameObject;
            StateMachine = GetComponent<Animator>();
        }

        public abstract bool Damage(float dmg, Vector2 dir);
        
    }
}
