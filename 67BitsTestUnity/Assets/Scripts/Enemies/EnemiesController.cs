using UnityEngine;
using MyUtilities;

public class EnemiesController : MonoBehaviour, Idamageble
{
    public Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();

    }
    public void TakeDamage(Transform targetTransform, int damage, float knockBackForce)
    {
        ApplyKnockBack(targetTransform, knockBackForce);
    }
    

    public void ApplyKnockBack(Transform targetTransform, float knockBackForce)
    {
        rig.KnockBack(transform, targetTransform, knockBackForce);
    }
}
