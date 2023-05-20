using UnityEngine;

namespace Strikezone
{
    public class UnitManager : MonoBehaviour
    {
        Transform _transform;
        public Unit Instance { get; private set; } 
        public UnitScriptableObject UnitScriptable { get; private set; }

        void Awake()
        {
            _transform = transform;
        }

        public void SetUnitScriptable(UnitScriptableObject newUnit)
        {
            UnitScriptable = newUnit;
            DestroyInstance();
            Instance = Instantiate(UnitScriptable.prefab, _transform);
        }

        public virtual void DestroyInstance()
        {
            if (Instance != null)
            {
                Destroy(Instance.InstanceGameobject);
            }
        }
    }
}
