using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadStore : MonoBehaviour
{
    // Start is called before the first frame update
    public Button merch;
    void Start()
    {
        merch.onClick.AddListener(Open);
    }
    private void Open()
    {
        Application.OpenURL("https://learn.unity.com/");
    }
}
