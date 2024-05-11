using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(fileName = "New Levels Scriptable", menuName = "Levels Scriptable")]
    public class LevelButtonsScriptable : ScriptableObject
    {
        public string[] LevelsSceneNames;
    }
}