using UnityEngine;

namespace Strikezone
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] DamagableFighter self;

        [SerializeField] float damage;
        [SerializeField] Vector2 kbDir;
        [SerializeField] float kbWeight;

        Collider2D _hitbox;

        void Awake()
        {
            _hitbox = GetComponent<Collider2D>();
        }

        Vector2 TotalKbDir(Vector2 hitDir)
        {
            return kbDir.normalized * kbWeight + hitDir.normalized * (1f - kbWeight);
        }
        
        void OnTriggerEnter2D(Collider2D col)
        {
            DamagableFighter fighter = col.attachedRigidbody.GetComponent<DamagableFighter>();

            if (fighter.Invincible)
            {
                self.PerformStun(damage);
                return;
            }

            var position = fighter.Rb.position;
            Vector2 hitDir = position - _hitbox.ClosestPoint(position);

            fighter.Damage(damage, TotalKbDir(hitDir));
        }
    }
}
