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
        if (PlayerPrefs.HasKey("DAY1"))
        {
            string fixtime = PlayerPrefs.GetString("DAY1");
            DateTime leftTime;
            if (DateTime.TryParse(fixtime, null, System.Globalization.DateTimeStyles.RoundtripKind, out leftTime))
            {
                TimeSpan needTime = DateTime.Now - leftTime;
                if (needTime.TotalSeconds >= requiretime1)
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
        PlayerPrefs.DeleteKey("DAY1");
        PlayerPrefs.Save();
        int day1 = CountDay1.LoadInter1();
        day1 += 1;
        CountDay1.SaveInter1(day1);
    }
    private void CreateCount()
    {
        CountDay1.CheckNum1();
    }
    private void Checker()
    {
        bool check = !PlayerPrefs.HasKey("DAY1");
        int count = CountDay1.LoadInter1();
        start.onClick.RemoveAllListeners();
        if (check && count < 10)
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
            SaveInter1(0);
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
