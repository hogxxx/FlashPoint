using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizStart : MonoBehaviour
{
    public Button start;
    public TextMeshProUGUI mes;
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        UpTime(); /*Change Place !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
        Checker();
    }
    
    public static void UpTime()
    {
        CountDay1.CheckNum1();
        int day1 = CountDay1.LoadInter1();
        day1 += 1;
        CountDay1.SaveInter1(day1);
    }
    private void Checker()
    {
        int count = CountDay1.LoadInter1();
        start.onClick.RemoveAllListeners();
        if (count < 31)
        {
            start.onClick.AddListener(Starter);
        }
        else
        {
            start.onClick.AddListener(Message);
        }
    }
    private void Starter()
    {
        SceneManager.LoadScene("Quizer");
    }
    public void Message()
    {
        StartCoroutine(Error());
    }
    private IEnumerator Error()
    {
        mes.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        mes.gameObject.SetActive(false);
    }
}
public static class CountDay1
{
    public static string filepath;
    private static void InitializeFile()
    {
        filepath = Application.persistentDataPath + "/inter1.json";
    }
    public static void CheckNum1()
    {
        if (!File.Exists(filepath))
        {
            InitializeFile();
            SaveInter1(-1);
        }
    }
    public static void SaveInter1(int num)
    {
        Numer1 numer = new Numer1();
        numer.num1 = num;
        string json = JsonUtility.ToJson(numer, true);
        File.WriteAllText(filepath, json);
    }
    public static int LoadInter1()
    {
        string json = File.ReadAllText(filepath);
        Numer1 numer = JsonUtility.FromJson<Numer1>(json);
        return numer.num1;
    }
}
[System.Serializable]
public class Numer1
{
    public int num1;
}
