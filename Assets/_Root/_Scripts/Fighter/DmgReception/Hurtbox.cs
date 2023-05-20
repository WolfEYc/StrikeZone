using UnityEngine;

namespace Strikezone
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField] GameObject hurboxes;

        void OnEnable()
        {
            hurboxes.SetActive(true);
        }

        void OnDisable()
        {
            hurboxes.SetActive(false);
        }
    }
}
