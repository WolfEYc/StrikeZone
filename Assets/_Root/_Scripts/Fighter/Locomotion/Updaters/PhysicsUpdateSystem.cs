using UnityEngine;

namespace Strikezone
{
    public class PhysicsUpdateSystem : MonoBehaviour
    {
        [SerializeField] PhysicsUpdater[] listeners;

        void FixedUpdate()
        {
            foreach (PhysicsUpdater listener in listeners)
            {
                if (listener.enabled)
                {
                    listener.PhysicsUpdate();
                }
            }
        }
    }
}
