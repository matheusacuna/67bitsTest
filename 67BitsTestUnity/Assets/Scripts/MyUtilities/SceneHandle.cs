using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneHandle : MonoBehaviour
    {
        public void LoadScene(string nameScene)
        {
            SceneManager.LoadScene(nameScene);
        }
    }

}

