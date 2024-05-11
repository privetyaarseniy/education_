using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class LevelButtonsInitializer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _buttonPrefab;
        [SerializeField]
        private LevelButtonsScriptable _levelsScenes;

        private void Awake()
        {
            int levelIndex = 1;
            foreach(var sceneName in _levelsScenes.LevelsSceneNames) 
            {
                Instantiate(_buttonPrefab, gameObject.transform).GetComponent<LevelButton>().Setup(sceneName, levelIndex);
                levelIndex++;
            }
        }
    }
}