using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameText;
    public void Initialize(string nameText)
    {
        _nameText.text = nameText;
    }
    public void OnClick()
    {
        SceneManager.LoadScene(_nameText.text);
    }
}
