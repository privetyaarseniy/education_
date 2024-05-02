using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class Startup : MonoBehaviour
    {
        [SerializeField]
        private string UIScene;

        private void Awake()
        {
            SceneManager.LoadScene(UIScene, LoadSceneMode.Single);
        }
    }
}