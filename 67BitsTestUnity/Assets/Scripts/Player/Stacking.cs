using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    // Array para armazenar os filhos
    public GameObject[] children;
    public List<Transform> cubes = new List<Transform>();
    public Transform stackingTransform;
    public float distance;
    public float swipeSpeed;

    void Start()
    {
        cubes.Add(stackingTransform.transform);
    }

    private void Update()
    {
        if (cubes.Count > 1)
        {
            for (int i = 1; i < cubes.Count; i++)
            {
                var FirstCube = cubes.ElementAt(i - 1);
                var SectCube = cubes.ElementAt(i);

                SectCube.position = new Vector3(
                                         Mathf.Lerp(SectCube.position.x, FirstCube.position.x, swipeSpeed * Time.deltaTime),
                                        FirstCube.position.y + 1.5f, // Ajuste para colocar o cubo em cima do cubo anterior
                                        Mathf.Lerp(SectCube.position.z, FirstCube.position.z, swipeSpeed * Time.deltaTime));
                SectCube.rotation = Quaternion.Euler(-90, 90, stackingTransform.eulerAngles.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemies"))
        {
            other.transform.parent = null;
            //other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.tag = gameObject.tag;
            cubes.Add(other.transform);
        }
    }
}
