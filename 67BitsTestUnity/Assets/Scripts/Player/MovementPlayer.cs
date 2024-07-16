using UnityEngine;
using Managers;

namespace Player
{
    public class MovementPlayer : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float rotationSpeed = 720f;
        private Rigidbody rb;
        private Animator anim;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            SetAnimations();
        }
        private void FixedUpdate()
        {
            DirectionPlayer();
        }

        private void DirectionPlayer()
        {
            Vector2 inputVector = MyInputs.GetInput().Player.Movement.ReadValue<Vector2>();

            Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
            rb.velocity = moveDirection * moveSpeed;

            // Rotacionar o personagem na direção do movimento
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }

        public void SetAnimations()
        {
            float velocityMagnitude = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
            anim.SetFloat("velocity", velocityMagnitude);
        }
    }
}
