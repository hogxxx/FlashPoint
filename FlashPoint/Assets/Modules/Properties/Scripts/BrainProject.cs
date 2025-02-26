using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;
using System.Security.Cryptography;
public class BrainProject : MonoBehaviour
{
    public Button start;
    public TextMeshProUGUI mes;
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Checker();
    }
    public static void UpTime()
    {
        CountDay.CheckNum();
        int day1 = CountDay.LoadInter();
        day1 += 6;
        CountDay.SaveInter(day1);
    }
    private void Checker()
    {
        int count = CountDay.LoadInter();
        start.onClick.RemoveAllListeners();
        if (count < 181)
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
        SceneManager.LoadScene("Training");
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
public static class CountDay
{
    public static string filepath;
    private static void InitializeFile()
    {
        filepath = Application.persistentDataPath + "/inter.json";
    }
    public static void CheckNum()
    {
        if (!File.Exists(filepath))
        {
            InitializeFile();
            SaveInter(0);
        }
    }
    public static void SaveInter(int num)
    {
        Numer numer = new Numer();
        numer.num1 = num;
        string json = JsonUtility.ToJson(numer,true);
        File.WriteAllText(filepath, json);
    }
    public static int LoadInter()
    {
        string json = File.ReadAllText(filepath);
        Numer numer = JsonUtility.FromJson<Numer>(json);
        return numer.num1; 
    }
}
[System.Serializable]
public class Numer
{
    public int num1;
}
