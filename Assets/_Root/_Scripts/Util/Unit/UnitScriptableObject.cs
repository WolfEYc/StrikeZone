using System;
using UnityEngine;

namespace Strikezone
{
    public abstract class UnitScriptableObject : ScriptableObject
    {
        [SerializeField] Sprite menuSprite;
        public Sprite MenuSprite => menuSprite;
    
        public Unit prefab;
    }
    
}