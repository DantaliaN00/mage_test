using UnityEngine;

namespace MageGame.Utilities
{
    public class DirectionMovement : MonoBehaviour
    {
        public float MoveSpeed { get; set; } = 3f;
        
        public float RotationSpeed { get; set; } = 100f;
        
        public Vector3 MoveDirection { get; set; } = Vector3.zero;
        public Quaternion Rotation { get; set; } = Quaternion.identity;
        
        void FixedUpdate()
        {
            transform.position += MoveSpeed * Time.fixedDeltaTime * MoveDirection;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, RotationSpeed * Time.fixedDeltaTime);
        }
    }
}