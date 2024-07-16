using UnityEngine;


namespace Player
{
    public class AttackCollider : MonoBehaviour
    {
        public MovementPlayer playerController;
        public DetectEnemies punchPlayer;

        public int damage;


        //Verifica se o objeto que est� colidindo possui a interface Idamageble para poder causar o efeito de Knockback
        //atrav�s da fun��o TakeDamage()
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
