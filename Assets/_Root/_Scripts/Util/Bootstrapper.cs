using UnityEngine;

namespace Strikezone
{
    public static class Bootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void SpawnSystems()
        {
            Object.Instantiate(Resources.Load("Systems"));
        }
    }
}
