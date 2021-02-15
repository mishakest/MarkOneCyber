using UnityEngine;

namespace Extensions
{
    public static class CapsuleColliderExtensions
    {
        public static void SetColliderHeight(this CapsuleCollider collider, float height)
        {
            var center = collider.center;
            center.y += (height - collider.height) / 2;
            collider.center = center;
            collider.height = height;
        }
    }
}