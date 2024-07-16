using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Player
{
    public class Stacking : MonoBehaviour
    {
        public List<Transform> enemiesTransform = new List<Transform>();
        public Transform stackingTransform;
        public float swipeSpeed;
        public float rotationSpeed = 5f;
        public int stackingLimit;
        private int currentAmountStacking;
        [SerializeField] private TextMeshProUGUI amountStacking;

        void Start()
        {
            amountStacking.text = $"0 / {stackingLimit}";
            stackingTransform.rotation = Quaternion.Euler(-90, stackingTransform.eulerAngles.y, 90f);
            enemiesTransform.Add(stackingTransform.transform);
        }

        private void Update()
        {    
            StackingEnemies();
        }

        private void StackingEnemies()
        {            
                if(enemiesTransform.Count > 1)
                {
                    for (int i = 1; i < enemiesTransform.Count; i++)
                    {
                        var firstEnemy = enemiesTransform.ElementAt(i - 1);
                        var secondEnemy = enemiesTransform.ElementAt(i);

                        // Ajustar a posi��o dos inimigos na costa do player.
                        secondEnemy.position = new Vector3(
                            Mathf.Lerp(secondEnemy.position.x, firstEnemy.position.x, swipeSpeed * Time.deltaTime),
                            firstEnemy.position.y + 1f, // Ajuste para colocar um inimigo em cima do outro inimigo.
                            Mathf.Lerp(secondEnemy.position.z, firstEnemy.position.z, swipeSpeed * Time.deltaTime));

                        // Ajustar a rota��o dos inmigos para ficarem na mesma dire��o do player, um por um.

                        Quaternion targetRotation = firstEnemy.rotation;
                        secondEnemy.rotation = Quaternion.Lerp(secondEnemy.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    }             
                }        
        }

        public void IncrementStackingAmountUI()
        {
            currentAmountStacking++;
            amountStacking.text = $"{currentAmountStacking} / {stackingLimit}";
        }

        public void DecrementStackingAmountUI()
        {
            currentAmountStacking--;
            amountStacking.text = $"{currentAmountStacking} / {stackingLimit}";
        }
    }
}
