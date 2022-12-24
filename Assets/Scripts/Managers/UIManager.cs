using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIの表示をこのクラスで行う
/// </summary>
public class UIManager : MonoBehaviour
{
    [Tooltip("シーン上に表示するText")]
    [SerializeField] private Text[] _sceneTexts = new Text[5];

    private void Update()
    {
        
    }
}
