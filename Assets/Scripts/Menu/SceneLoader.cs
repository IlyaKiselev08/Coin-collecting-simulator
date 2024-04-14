using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string[] _scenes;
    [SerializeField]
    private SceneElement _sceneElement;
    private void OnEnable()
    {
        Load();
    }
    private void Load()
    {
        Clear();
        foreach(var scene in _scenes)
        {
            SceneElement element = Instantiate(_sceneElement, transform);
            element.Initialize(scene);
        }
    }
    private void Clear()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
