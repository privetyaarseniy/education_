using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene((int)Scenes.UI, LoadSceneMode.Single);
    }
}
