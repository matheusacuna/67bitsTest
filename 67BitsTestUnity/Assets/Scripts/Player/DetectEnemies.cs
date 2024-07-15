using UnityEngine;


namespace Player
{
    public class DetectEnemies : MonoBehaviour
    {
        private Animator anim;
        //[SerializeField] private Stacking stacking;
        public float forceKnockback;
        // Start is called before the first frame update
        void Start()
        {
            anim = gameObject.GetComponentInParent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                Debug.Log("touching");
                anim.SetTrigger("basicAttack");
            }
        }
    }
}

