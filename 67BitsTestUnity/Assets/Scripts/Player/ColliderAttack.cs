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
                Debug.Log("obj is not null");
                if (playerController != null)
                {
                    Debug.Log("playerController is not null");
                    obj.TakeDamage(playerController.transform, damage, punchPlayer.forceKnockback);
                }
                else
                {
                    Debug.LogError("playerController is null");
                }
            }
            else
            {
                Debug.LogError("obj is null");
            }

        }
    }
}
