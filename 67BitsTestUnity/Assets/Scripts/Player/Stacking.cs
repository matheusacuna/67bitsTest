using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    public GameObject[] children;
    public List<Transform> cubes = new List<Transform>();
    public Transform stackingTransform;
    public float distance;
    public float swipeSpeed;
    public float rotationSpeed = 5f; // Velocidade de rotação

    void Start()
    {
        stackingTransform.rotation = Quaternion.Euler(-90, stackingTransform.eulerAngles.y, 90f);
        cubes.Add(stackingTransform.transform);
    }

    private void Update()
    {
        StackingObjects();
    }

    private void StackingObjects()
    {
        if(cubes.Count > 1)
        {
            for (int i = 1; i < cubes.Count; i++)
            {
                var FirstCube = cubes.ElementAt(i - 1);
                var SectCube = cubes.ElementAt(i);

                // Ajustar a posição dos cubos
                SectCube.position = new Vector3(
                    Mathf.Lerp(SectCube.position.x, FirstCube.position.x, swipeSpeed * Time.deltaTime),
                    FirstCube.position.y + 1f, // Ajuste para colocar o cubo em cima do cubo anterior
                    Mathf.Lerp(SectCube.position.z, FirstCube.position.z, swipeSpeed * Time.deltaTime));

                // Ajustar a rotação dos cubos para ficarem na mesma direção do player, um por um

                Quaternion targetRotation = FirstCube.rotation;
                SectCube.rotation = Quaternion.Lerp(SectCube.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("enemies"))
    //    {
    //        other.transform.parent = null;
    //        other.gameObject.GetComponent<Collider>().isTrigger = true;
    //        other.tag = gameObject.tag;
    //        cubes.Add(other.transform);

    //        if (cubes.Count > 1)
    //        {
    //            other.transform.rotation = Quaternion.Euler(-90, other.transform.eulerAngles.y, 90);
    //        }
    //    }
    //}
}
