using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OrderClass : MonoBehaviour
{
    // Start is called before the first frame update
    public ToggleGroup group;
    public Button ready;
    private int classnum;
    void Start()
    {
        foreach (Toggle point in group.GetComponentsInChildren<Toggle>())
        {
                point.onValueChanged.AddListener(delegate { Checker(point); });
        }
        ready.onClick.AddListener(Save);
    }
    private void Checker(Toggle point)
    {
        if (point.isOn)
        {
            TextMeshProUGUI classer = point.GetComponentInChildren<TextMeshProUGUI>(true);
            string classers = classer.text;
            int.TryParse(classers, out classnum);
        }
    }
    private void Save()
    {
        Debug.Log(classnum);
        PlayerPrefs.SetInt("Class", classnum);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Objects");
    }
}
