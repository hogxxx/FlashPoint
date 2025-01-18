using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button back;
    void Start()
    {
        back.onClick.AddListener(Load);
    }
    public void Load()
    {
        SceneManager.LoadScene("Menu");
    }
}
