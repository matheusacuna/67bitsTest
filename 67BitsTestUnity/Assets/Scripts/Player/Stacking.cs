using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Player
{
    public class Stacking : MonoBehaviour
    {
        public GameObject[] children;
        public List<Transform> cubes = new List<Transform>();
        public Transform stackingTransform;
        public float distance;
        public float swipeSpeed;
        public float rotationSpeed = 5f;

        void Start()
        {
            stackingTransform.rotation = Quaternion.Euler(-90, stackingTransform.eulerAngles.y, 90f);
            cubes.Add(stackingTransform.transform);
        }

        private void Update()
        {
            StackingEnemies();
        }

        private void StackingEnemies()
        {
            if(cubes.Count > 1)
            {
                for (int i = 1; i < cubes.Count; i++)
                {
                    var firstEnemy = cubes.ElementAt(i - 1);
                    var secondEnemy = cubes.ElementAt(i);

                    // Ajustar a posição dos inimigos na costa do player.
                    secondEnemy.position = new Vector3(
                        Mathf.Lerp(secondEnemy.position.x, firstEnemy.position.x, swipeSpeed * Time.deltaTime),
                        firstEnemy.position.y + 1f, // Ajuste para colocar um inimigo em cima do outro inimigo.
                        Mathf.Lerp(secondEnemy.position.z, firstEnemy.position.z, swipeSpeed * Time.deltaTime));

                    // Ajustar a rotação dos inmigos para ficarem na mesma direção do player, um por um.

                    Quaternion targetRotation = firstEnemy.rotation;
                    secondEnemy.rotation = Quaternion.Lerp(secondEnemy.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}
