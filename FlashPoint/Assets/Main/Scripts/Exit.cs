using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Button exitButton;
    void Start()
    {
        exitButton.onClick.AddListener(Exit1);
    }
    public void Exit1()
    {
        SceneManager.LoadScene(0);
    }

}
