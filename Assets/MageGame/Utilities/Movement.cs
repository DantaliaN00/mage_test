using JetBrains.Annotations;
using UnityEngine;

namespace MageGame.Utilities
{
    public class Movement : MonoBehaviour
    {
        public float MoveSpeed { get; set; } = 3f;

        public float RotationSpeed { get; set; } = 10f;
        
        [CanBeNull]
        public Transform Target { get; set; }

        void FixedUpdate()
        {
            if (Target == null)
                return;
            
            transform.position = Vector3.MoveTowards(transform.position, Target.position, MoveSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.position - Target.position), RotationSpeed * Time.fixedDeltaTime);
        }
    }
}
