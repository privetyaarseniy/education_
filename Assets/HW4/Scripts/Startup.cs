using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HW4
{
    public class Startup : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene((int)HW4.Scenes.UI, LoadSceneMode.Additive);
            SceneManager.LoadScene((int)HW4.Scenes.Game, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync((int)HW4.Scenes.Startup);
        }
    }
}
