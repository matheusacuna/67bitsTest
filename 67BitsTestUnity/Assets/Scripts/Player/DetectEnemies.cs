using UnityEngine;

namespace Player
{
    public class DetectEnemies : MonoBehaviour
    {
        private Animator anim;
        public float forceKnockback;
        void Start()
        {
            anim = gameObject.GetComponentInParent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                anim.SetTrigger("basicAttack");
            }
        }
    }
}

