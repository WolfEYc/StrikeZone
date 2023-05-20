using System.Collections;
using UnityEngine;

namespace Strikezone
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DamagableFighter : Unit
    {
        Stun _stun;
        public Rigidbody2D Rb { get; private set; }
        public float TotalDamage { get; private set; }
        public bool Invincible { get; set; }

        const float StunDurationMult = 1f;

        protected override void Awake()
        {
            base.Awake();
            Rb = GetComponent<Rigidbody2D>();
            _stun = GetComponent<Stun>();
        }

        public override bool Damage(float dmg, Vector2 dir)
        {
            if (Invincible) return false;

            TotalDamage += dmg;
            PerformStun(dmg);
            
            
            return true;
        }

        public void PerformStun(float dmg)
        {
            _stun.PerformStun(dmg * TotalDamage * StunDurationMult);
        }
        

        public virtual void Reset()
        {
            TotalDamage = 0f;
        }
    }
}
