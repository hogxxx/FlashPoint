using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{
  
    void Start()
    {
        if (!PlayerPrefs.HasKey("Class"))
        {
            SceneManager.LoadScene("Class");
        }
        else if (!PlayerPrefs.HasKey("Object"))
        {
            SceneManager.LoadScene("Objects");
        }
    }
}
