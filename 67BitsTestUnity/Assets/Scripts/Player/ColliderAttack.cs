using UnityEngine;


namespace Player
{
    public class AttackCollider : MonoBehaviour
    {
        public MovementPlayer playerController;
        public DetectEnemies punchPlayer;

        public int damage;


        private void OnTriggerEnter(Collider other)
        {
            Idamageble obj = other.gameObject.GetComponent<Idamageble>();

            if (obj != null)
            {
                obj.TakeDamage(playerController.transform, damage, punchPlayer.forceKnockback);
            }
        }
    }
}
