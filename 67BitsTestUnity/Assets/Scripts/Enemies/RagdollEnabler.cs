using UnityEngine;

public class RagdollEnabler : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform ragdollRoot;
    public bool startRagdoll = false;

    public Rigidbody[] rigidBodies;
    private CharacterJoint[] joints;
    private Collider[] colliders;


    private void Awake()
    {
        rigidBodies = ragdollRoot.GetComponentsInChildren<Rigidbody>();
        joints = ragdollRoot.GetComponentsInChildren<CharacterJoint>();
        colliders = ragdollRoot.GetComponentsInChildren<Collider>();
    }

    //Ativa o efeito de Ragdoll nos inimigos.
    public void EnableRagdoll()
    {
        animator.enabled = false;
        foreach (CharacterJoint joint in joints)
        {
            joint.enableCollision = true;
        }
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
        foreach (Rigidbody rigidbody in rigidBodies)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.detectCollisions = true;
            rigidbody.useGravity = true;
        }
    }

    //Desativa o efeito de Ragdoll e ativa o animator.
    public void EnableAnimator()
    {
        animator.enabled = true;
        foreach (CharacterJoint joint in joints)
        {
            joint.enableCollision = false;
        }
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (Rigidbody rigidbody in rigidBodies)
        {
            rigidbody.detectCollisions = false;
            rigidbody.useGravity = false;
        }
    }


}
