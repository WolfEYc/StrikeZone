using UnityEngine;

namespace Strikezone
{
    public class UnitsLoader : MonoBehaviour
    {
        [SerializeField] UnitScriptableObject[] units;
        public UnitScriptableObject[] Units => units;

        public UnitScriptableObject RandomUnit()
        {
            return units[Random.Range(0, units.Length)];
        }
    }
}
