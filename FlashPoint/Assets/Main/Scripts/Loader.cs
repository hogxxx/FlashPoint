using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
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
