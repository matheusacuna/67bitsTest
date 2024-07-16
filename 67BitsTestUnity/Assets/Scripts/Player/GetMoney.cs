using Managers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    //public float radiusCollider;
    [Header("Scripts Reference")]
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private Stacking stackingManager;
    //[SerializeField] private StackingManager stackingManager;


    void Update()
    {
        //IdentifyPool();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PoolMoney"))
        {
            for (int i = 0; i < stackingManager.enemiesTransform.Count; i++)
            {
                StartCoroutine(RemoveEnemiesWithDelay());
            }
        }
    }
    private IEnumerator RemoveEnemiesWithDelay()
    {
        // Enquanto houver mais de um objeto na lista, remova o último com um delay de 1.5 segundos
        while (stackingManager.enemiesTransform.Count > 1)
        {
            // Acessa o último objeto da lista
            Transform lastEnemy = stackingManager.enemiesTransform[stackingManager.enemiesTransform.Count - 1];

            // Remove o objeto da lista
            stackingManager.enemiesTransform.RemoveAt(stackingManager.enemiesTransform.Count - 1);

            // Destrói o objeto
            Destroy(lastEnemy.gameObject);

            // Espera 1.5 segundos antes de continuar
            yield return new WaitForSeconds(1.5f);
        }
    }

    //public void IdentifyPool()
    //{
    //    Collider[] hit = Physics.OverlapSphere(transform.position, radiusCollider);

    //    foreach (var item in hit)
    //    {
    //        if (item.gameObject.layer == LayerMask.NameToLayer("PoolMoney"))
    //        {
    //            shopManager.IncrementMoney(10f);
    //            //Feedback();
    //            //stackingManager.currentStackAmount = 0;
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, radiusCollider);
    //}

    //public void Feedback()
    //{
    //    shopManager.feedbackMoney.GetComponent<Animator>().Play("feedbackMoney", -1, 0.0f);
    //}
}
