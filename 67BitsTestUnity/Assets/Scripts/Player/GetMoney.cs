using Managers;
using Player;
using System.Collections;
using TMPro;
using UnityEngine;


namespace Player
{
    public class GetMoney : MonoBehaviour
    {
        [Header("Scripts Reference")]
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private Stacking stackingManager;
        
        private bool isRemoving = false;

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("PoolMoney"))
            {
                if (!isRemoving)
                {
                    StartCoroutine(RemoveEnemiesWithDelay());
                }
            }
        }
        private IEnumerator RemoveEnemiesWithDelay()
        {
            isRemoving = true;

            yield return new WaitForSeconds(1.5f);
            // Enquanto houver mais de um objeto na lista, remova o �ltimo com um delay de 1.5 segundos
            while (stackingManager.enemiesTransform.Count > 1)
            {
                // Acessa o �ltimo objeto da lista
                Transform lastEnemy = stackingManager.enemiesTransform[stackingManager.enemiesTransform.Count - 1];

                // Remove o objeto da lista
                stackingManager.enemiesTransform.RemoveAt(stackingManager.enemiesTransform.Count - 1);

                // Destr�i o objeto
                Destroy(lastEnemy.gameObject);

                stackingManager.UpdateStackingAmountUI();
                shopManager.IncrementMoney(10f);

                // Espera 1.5 segundos antes de continuar
                yield return new WaitForSeconds(1.5f);
            }

            isRemoving = false;
        }
    }
}
