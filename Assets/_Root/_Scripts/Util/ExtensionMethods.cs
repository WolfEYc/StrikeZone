using UnityEngine;

namespace Strikezone
{
    public static class ExtensionMethods
    {
        const float DefaultSpriteAngle = 90f;
        
        public static void DestroyChildren(this Transform t)
        {
            foreach (Transform child in t)
            {
                Object.Destroy(child.gameObject);
            }
        }

        public static void AddLayer(this ref LayerMask originalLayerMask, int layerToAdd)
        {
            originalLayerMask |= (1 << layerToAdd);
        }
        
        public static void RemoveLayer(this ref LayerMask originalLayerMask, int layerToRemove)
        {
            originalLayerMask &= ~(1 << layerToRemove);
        }
        
        public static float LookAtRot(Vector2 pos)
        {
            pos.Normalize();
            return Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - DefaultSpriteAngle;
        }

        public static void OrientAlongVelocity(this Rigidbody2D rb)
        {
            if(rb.velocity == Vector2.zero) return;
            rb.rotation = LookAtRot(rb.velocity);
        }
    }
}
