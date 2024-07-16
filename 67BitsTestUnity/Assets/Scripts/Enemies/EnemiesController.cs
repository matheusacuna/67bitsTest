using UnityEngine;
using MyUtilities;
using System.Collections;
using Player;

public class EnemiesController : MonoBehaviour, Idamageble
{
    [Header("Stacking Enemy Settings")]
    [SerializeField] Stacking stackingManager;
    [SerializeField] private RagdollEnabler[] Ragdolls;
    [SerializeField] private GameObject vfx; 
    public bool isAffected;

    public void TakeDamage(Transform targetTransform, int damage, float knockBackForce)
    {
        ApplyKnockBack(targetTransform, knockBackForce);
        StartCoroutine(StackingEnemies());
    }

    public void ApplyKnockBack(Transform targetTransform, float knockBackForce)
    {
        foreach (RagdollEnabler ragdoll in Ragdolls)
        {
            ragdoll.EnableRagdoll();
        }
        foreach (RagdollEnabler ragdoll in Ragdolls)
        {
            foreach (Rigidbody rigidbody in ragdoll.rigidBodies)
            {
                rigidbody.KnockBack(transform, targetTransform, knockBackForce);
            }
        }
    }

    public IEnumerator StackingEnemies()
    {
        yield return new WaitForSeconds(1);

        vfx.SetActive(true);

        GetComponent<BoxCollider>().enabled = false;

        foreach (RagdollEnabler ragdoll in Ragdolls)
        {
            ragdoll.EnableAnimator();
        }

        gameObject.transform.parent = null;
        stackingManager.enemiesTransform.Add(gameObject.transform);

        if (stackingManager.enemiesTransform.Count > 1)
        {
            gameObject.transform.rotation = Quaternion.Euler(-90, gameObject.transform.eulerAngles.y, 90);
        }
    }
}
