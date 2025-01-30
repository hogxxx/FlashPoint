using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FactsControl : MonoBehaviour
{
    public GameObject a1;
    public GameObject a2;
    public GameObject a12;
    public GameObject a23;
    public Button b1;
    public Button b2;
    public Button e;
    private void Start()
    {
        b1.onClick.AddListener(a11);
        b2.onClick.AddListener(a22);
        e.onClick.AddListener(Exit);
    }
    void a11()
    {
        a12.SetActive(false);
        a23.SetActive(true);
        a1.SetActive(true);
        a2.SetActive(false);
    }
    void a22()
    {
        a12.SetActive(false);
        a23.SetActive(true);
        a2.SetActive(true);
        a1.SetActive(false);
    }
    private void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
