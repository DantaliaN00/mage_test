using JetBrains.Annotations;
using UnityEngine;

namespace MageGame.Utilities
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] 
        float moveSpeed = 3f;

        [SerializeField] 
        float rotationSpeed = 10f;
        
        [CanBeNull]
        public Transform Target { get; set; }

        void FixedUpdate()
        {
            if (Target == null)
                return;
            
            transform.position = Vector3.MoveTowards(transform.position, Target.position, moveSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.position - Target.position), rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
