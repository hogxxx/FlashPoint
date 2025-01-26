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
    private float requiretime1 = 86400f;
    public Button start;
    public TextMeshProUGUI mes;
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        CheckDayOne();
        CreateCount();
        Checker();
    }
    private void CheckDayOne()
    {
        if (PlayerPrefs.HasKey("Day1"))
        {
            string fixtime = PlayerPrefs.GetString("Day1");
            DateTime leftTime;
            if(DateTime.TryParse(fixtime,null,System.Globalization.DateTimeStyles.RoundtripKind,out leftTime))
            {
                TimeSpan needTime = DateTime.Now - leftTime;
                if(needTime.TotalSeconds >= requiretime1)
                {
                    UpTime();
                }
                else
                {
                    float enoughTime = (float)(requiretime1 - needTime.TotalSeconds);
                    Invoke("UpTime", enoughTime);
                }
            }
        }
    }
    private void UpTime()
    {
        PlayerPrefs.DeleteKey("Day1");
        PlayerPrefs.Save();
        int day1 = CountDay.LoadInter();
        day1 += 6;
        CountDay.SaveInter(day1);
    }
    private void CreateCount()
    {
        CountDay.CheckNum();
    }
    private void Checker()
    {
        bool check = !PlayerPrefs.HasKey("Day1");
        int count = CountDay.LoadInter();
        start.onClick.RemoveAllListeners();
        if (check && count < 49)
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
            SaveInter(6);
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
