using UnityEngine;

namespace PPRG.Colliders
{
    /// <summary>
    /// Provides Subscribable colliders.
    /// </summary>
    public class SubscribableCollider : MonoBehaviour
    {
        // Keep track of the collider.
        private Collider _trackedCollider = null;

        // Delegates.
        public delegate void CollisionEvent(Collision collision);
        public delegate void TriggerEvent(Collider collider);

        // Events.
        public event CollisionEvent OnPhysicsCollisionEnter;
        public event CollisionEvent OnPhysicsCollisionExit;
        public event CollisionEvent OnPhysicsCollisionStay;
        public event TriggerEvent OnPhysicsTriggerEnter;
        public event TriggerEvent OnPhysicsTriggerExit;
        public event TriggerEvent OnPhysicsTriggerStay;

        /// <summary>
        /// Initializes the class and creates a collider with the specified type.
        /// </summary>
        /// <param name="colliderType">The type of collider to add.</param>
        public void Initialize(System.Type colliderType)
        {
            _trackedCollider = (Collider)gameObject.AddComponent(colliderType);
        }

        /// <summary>
        /// Initializes the class and tracks the passed collider.
        /// </summary>
        /// <param name="colliderType">The collider to track.</param>
        public void Initialize(Collider collider)
        {
            _trackedCollider = collider;
        }

        /// <summary>
        /// Returns the currently tracked collider.
        /// </summary>
        /// <returns>The currently tracked collider</returns>
        public Collider GetTrackedCollider()
        {
            return _trackedCollider;
        }

        void OnCollisionEnter(Collision collision)
        {
            OnPhysicsCollisionEnter?.Invoke(collision);
        }

        void OnCollisionExit(Collision collision)
        {
            OnPhysicsCollisionExit?.Invoke(collision);
        }

        void OnCollisionStay(Collision collision)
        {
            OnPhysicsCollisionStay?.Invoke(collision);
        }

        void OnTriggerEnter(Collider collider)
        {
            OnPhysicsTriggerEnter?.Invoke(collider);
        }

        void OnTriggerExit(Collider collider)
        {
            OnPhysicsTriggerExit?.Invoke(collider);
        }

        void OnTriggerStay(Collider collider)
        {
            OnPhysicsTriggerStay?.Invoke(collider);
        }

    }
}
