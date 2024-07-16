using Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class GetMoney : MonoBehaviour
    {
        [Header("Scripts Reference")]
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private Stacking stackingManager;
        [SerializeField] private Slider delaySlider;
        
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
            float delay = 1.5f;

            delaySlider.gameObject.SetActive(true);

            // Enquanto houver objetos na lista, remova o último com um delay
            while (stackingManager.enemiesTransform.Count > 1)
            {
                float elapsedTime = 0f;

                // Atualiza o slider enquanto espera 1.5 segundos
                while (elapsedTime < delay)
                {
                    elapsedTime += Time.deltaTime;
                    delaySlider.value = elapsedTime / delay;
                    yield return null;
                }

                // Reseta o slider
                delaySlider.value = 0f;

                // Acessa o último objeto da lista
                Transform lastEnemy = stackingManager.enemiesTransform[stackingManager.enemiesTransform.Count - 1];

                // Remove o objeto da lista
                stackingManager.enemiesTransform.RemoveAt(stackingManager.enemiesTransform.Count - 1);

                // Destrói o objeto
                Destroy(lastEnemy.gameObject);

                stackingManager.DecrementStackingAmountUI();
            }

            // Desativa o sliderObject após o último objeto ser deletado
            delaySlider.gameObject.SetActive(false);

            isRemoving = false;
        }
    }
}
