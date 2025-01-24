using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button exit;
    private void Start()
    {
        exit.onClick.AddListener(ex);

    }
    void ex()
    {
        Application.Quit();
    }
}
