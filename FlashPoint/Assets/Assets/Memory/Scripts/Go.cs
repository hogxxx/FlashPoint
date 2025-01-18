using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Go : MonoBehaviour
{
    public Button remember;
    public Button terms;

    private float requiretime = 30f;
    private float requiretime1 = OrderTime.requiretime;
    private float requiretime2 = 60f;
    private float requiretime3 = 90f;
    private float requiretime4 = 120f;
    public TextMeshProUGUI mes;
    private string CorrectRrepetition1;
    private string Correctkey1;
    private string NotCorrectRrepetition1;
    private string NotCorrectRrepetition2;
    private string NotCorrectkey2;
    private string repetitions;
    private int chooser;
    void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
            CreatingKeys();
            Weeker();
            Oneday();
            CheckCorrectAnswers();
            CheckNotCorrectAnswers();
            Checker();
    }
    void Start()
    {
        terms.onClick.AddListener(Terms);
    }
    private void CreatingKeys()
    {
        if (!PlayerPrefs.HasKey("Updating"))
        {
            PlayerPrefs.SetInt("Updating", 0);
        }
        if (!PlayerPrefs.HasKey("Note"))
        {
            PlayerPrefs.SetInt("Note", 0);
        }
        if (!PlayerPrefs.HasKey("Note3"))
        {
            PlayerPrefs.SetInt("Note3", 0);
        }
        if (!PlayerPrefs.HasKey("Repeat3"))
        {
            PlayerPrefs.SetInt("Repeat3", 0);
        }
        if (!PlayerPrefs.HasKey("Note4"))
        {
            PlayerPrefs.SetInt("Note4", 0);
        }
        if (!PlayerPrefs.HasKey("Repeat4"))
        {
            PlayerPrefs.SetInt("Repeat4", 0);
        }
        if (!PlayerPrefs.HasKey("1Again"))
        {
            PlayerPrefs.SetString("1Again", "");
        }
        if (!PlayerPrefs.HasKey("11Again"))
        {
            PlayerPrefs.SetString("11Again", "");
        }
        if (!PlayerPrefs.HasKey("111Again"))
        {
            PlayerPrefs.SetString("111Again", "");
        }
        if (!PlayerPrefs.HasKey("CorrectsKeys1"))
        {
            PlayerPrefs.SetString("CorrectsKeys1", "");
        }
        if (!PlayerPrefs.HasKey("CorrectsKeys11"))
        {
            PlayerPrefs.SetString("CorrectsKeys11", "");
        }
        if (!PlayerPrefs.HasKey("CorrectsKeys111"))
        {
            PlayerPrefs.SetString("CorrectsKeys111", "");
        }
        if (!PlayerPrefs.HasKey("2Again1"))
        {
            PlayerPrefs.SetString("2Again1", "");
        }
        if (!PlayerPrefs.HasKey("2Agains"))
        {
            PlayerPrefs.SetString("2Agains", "");
        }
        if (!PlayerPrefs.HasKey("NotCorrectsKeys2"))
        {
            PlayerPrefs.SetString("NotCorrectsKeys2", "");
        }
        if (!PlayerPrefs.HasKey("3Again1"))
        {
            PlayerPrefs.SetString("3Again1", "");
        }
        if (!PlayerPrefs.HasKey("3Again2"))
        {
            PlayerPrefs.SetString("3Again2", "");
        }
        if (!PlayerPrefs.HasKey("3Again3"))
        {
            PlayerPrefs.SetString("3Again3", "");
        }
        if (!PlayerPrefs.HasKey("NotCorrectsKeys3"))
        {
            PlayerPrefs.SetString("NotCorrectsKeys3", "");
        }
        if (!PlayerPrefs.HasKey("4Again1"))
        {
            PlayerPrefs.SetString("4Again1", "");
        }
        if (!PlayerPrefs.HasKey("4Again2"))
        {
            PlayerPrefs.SetString("4Again2", "");
        }
        if (!PlayerPrefs.HasKey("4Again3"))
        {
            PlayerPrefs.SetString("4Again3", "");
        }
        if (!PlayerPrefs.HasKey("4Again4"))
        {
            PlayerPrefs.SetString("4Again4", "");
        }
        if (!PlayerPrefs.HasKey("NotCorrectsKeys4"))
        {
            PlayerPrefs.SetString("NotCorrectsKeys4", "");
        }
        if (!PlayerPrefs.HasKey("AllKeysCheck2"))
        {
            PlayerPrefs.SetString("AllKeysCheck2", "");
        }
        PlayerPrefs.Save();
    }
    private void Oneday()
    {
        if (PlayerPrefs.HasKey("RequireTime"))
        {
            string timers = PlayerPrefs.GetString("RequireTime");
            DateTime lefttime;
            if (DateTime.TryParse(timers, null, System.Globalization.DateTimeStyles.RoundtripKind, out lefttime))
            {
                TimeSpan usedtimes = DateTime.Now - lefttime;
                if (usedtimes.TotalSeconds >= requiretime1)
                {
                    UpTime1();
                }
                else
                {
                    float enoughtime = (float)(requiretime1 - usedtimes.TotalSeconds);
                    Invoke("UpTime1", enoughtime);
                }
            }
        }
    }
    private /*async*/ void Weeker()
    {
        if (PlayerPrefs.HasKey("Week7"))
        {

            /* await Notification.SendNotification("Memory", "З'явилися нові терміни для повторень на тиждень!", requiretime); */
            string timers = PlayerPrefs.GetString("Week7");
            DateTime lefttime;
            if (DateTime.TryParse(timers, null, System.Globalization.DateTimeStyles.RoundtripKind, out lefttime))
            {
                TimeSpan usedtimes = DateTime.Now - lefttime;
                if (usedtimes.TotalSeconds >= requiretime)
                {
                    UpTime();
                }
                else
                {
                    float enoughtime = (float)(requiretime - usedtimes.TotalSeconds);
                    Invoke("UpTime", enoughtime);
                }
            }
        }
        else
        {
            int countWeek = PlayerPrefs.GetInt("Updating");
            chooser = PlayerPrefs.GetInt("Chooser");
            Debug.Log(countWeek);
            Debug.Log(chooser);
            if (countWeek < chooser)
            {
                PlayerPrefs.SetString("Week7", System.DateTime.Now.ToString("o"));
                PlayerPrefs.Save();
                Weeker();
            }
        }
    }
    private void CheckCorrectAnswers()
    {
        foreach (var key in PlayerPrefsKeys())
        {
            if (key.StartsWith("CorrectAnswer_"))
            {
                string term = PlayerPrefs.GetString(key);
                TermData termdata = JsonUtility.FromJson<TermData>(term);
                /*SendNote(termdata.term, requiretime2);*/
                DateTime fixedtime;
                if (DateTime.TryParse(termdata.data, null, System.Globalization.DateTimeStyles.RoundtripKind, out fixedtime))
                { 
                    TimeSpan lefttime = DateTime.Now - fixedtime;
                    if (lefttime.TotalSeconds >= requiretime2)
                    {
                        GoodAnswered(termdata.term,key);
                    }
                    else
                    {
                        float enoughtime = (float)(requiretime2 - lefttime.TotalSeconds);
                        StartCoroutine(WaiterLoad1(termdata.term, key, enoughtime));
                    }
                }
            }
            if (key.StartsWith("CorrectAnswer1_"))
            {
                Debug.Log("YES I CAN");
                string term = PlayerPrefs.GetString(key);
                TermData termdata = JsonUtility.FromJson<TermData>(term);
                /*SendNote(termdata.term, requiretime3);*/
                DateTime fixedtime;
                if (DateTime.TryParse(termdata.data, null, System.Globalization.DateTimeStyles.RoundtripKind, out fixedtime))
                {
                    TimeSpan lefttime = DateTime.Now - fixedtime;
                    if (lefttime.TotalSeconds >= requiretime3)
                    {
                        GoodAnswered1(termdata.term, key);
                    }
                    else
                    {
                        float enoughtime = (float)(requiretime3 - lefttime.TotalSeconds);
                        StartCoroutine(WaiterLoad1(termdata.term, key, enoughtime));
                    }
                }
            }
            if (key.StartsWith("CorrectAnswer2_"))
            {
                string term = PlayerPrefs.GetString(key);
                TermData termdata = JsonUtility.FromJson<TermData>(term);
                /*SendNote(termdata.term, requiretime4);*/
                DateTime fixedtime;
                if (DateTime.TryParse(termdata.data, null, System.Globalization.DateTimeStyles.RoundtripKind, out fixedtime))
                {
                    TimeSpan lefttime = DateTime.Now - fixedtime;
                    if (lefttime.TotalSeconds >= requiretime4)
                    {
                        GoodAnswered2(termdata.term, key);
                    }
                    else
                    {
                        float enoughtime = (float)(requiretime4 - lefttime.TotalSeconds);
                        StartCoroutine(WaiterLoad1(termdata.term, key, enoughtime));
                    }
                }
            }
        }
        PlayerPrefs.Save();
    }
    private IEnumerator WaiterLoad1(string term,string key,float wait)
    {
        yield return new WaitForSeconds(wait);
        if (key.StartsWith("CorrectAnswer_"))
        {
            GoodAnswered(term, key);
        }
        if (key.StartsWith("CorrectAnswer1_"))
        {
            GoodAnswered1(term, key);
        }
        if (key.StartsWith("CorrectAnswer2_"))
        {
            GoodAnswered2(term, key);
        }
    }
    private void GoodAnswered(string term,string key)
    {
        Addrepeat(term);
        string CorrectExistTerm = PlayerPrefs.GetString("1Again");
        string correctkey1 = PlayerPrefs.GetString("CorrectsKeys1");
        if (!string.IsNullOrEmpty(CorrectExistTerm) && !string.IsNullOrEmpty(correctkey1))
        {
            CorrectRrepetition1 = CorrectExistTerm + ";" + term;
            Correctkey1 = correctkey1 + ";" + key;
        }
        else
        {
            CorrectRrepetition1 = term;
            Correctkey1 = key;
        }
        PlayerPrefs.SetString("CorrectsKeys1",Correctkey1);
        PlayerPrefs.SetString("1Again", CorrectRrepetition1);
        PlayerPrefs.Save();
        Checker();
    }
    private void GoodAnswered1(string term, string key)
    {
        Addrepeat(term);
        string CorrectExistTerm = PlayerPrefs.GetString("11Again");
        string correctkey1 = PlayerPrefs.GetString("CorrectsKeys11");
        if (!string.IsNullOrEmpty(CorrectExistTerm) && !string.IsNullOrEmpty(correctkey1))
        {
            CorrectRrepetition1 = CorrectExistTerm + ";" + term;
            Correctkey1 = correctkey1 + ";" + key;
        }
        else
        {
            CorrectRrepetition1 = term;
            Correctkey1 = key;
        }
        PlayerPrefs.SetString("CorrectsKeys11", Correctkey1);
        PlayerPrefs.SetString("11Again", CorrectRrepetition1);
        PlayerPrefs.Save();
        Checker();
    }
    private void GoodAnswered2(string term, string key)
    {
        Addrepeat(term);
        string CorrectExistTerm = PlayerPrefs.GetString("111Again");
        string correctkey1 = PlayerPrefs.GetString("CorrectsKeys111");
        if (!string.IsNullOrEmpty(CorrectExistTerm) && !string.IsNullOrEmpty(correctkey1))
        {
            CorrectRrepetition1 = CorrectExistTerm + ";" + term;
            Correctkey1 = correctkey1 + ";" + key;
        }
        else
        {
            CorrectRrepetition1 = term;
            Correctkey1 = key;
        }
        PlayerPrefs.SetString("CorrectsKeys111", Correctkey1);
        PlayerPrefs.SetString("111Again", CorrectRrepetition1);
        PlayerPrefs.Save();
        Checker();
    }
    private void CheckNotCorrectAnswers()
    {
        foreach (var key in PlayerPrefsKeys())
        {
            if (key.StartsWith("NotCorrectAnswer_"))
            {
                Debug.Log("NotCorrectAnswer key found: " + key);
                string term = PlayerPrefs.GetString(key);
                TermData termdata = JsonUtility.FromJson<TermData>(term);
                /*SendNote(termdata.term, requiretime2);*/
                DateTime fixedtime;

                if (DateTime.TryParse(termdata.data, null, System.Globalization.DateTimeStyles.RoundtripKind, out fixedtime))
                {
                    TimeSpan lefttime = DateTime.Now - fixedtime;
                    if (lefttime.TotalSeconds >= requiretime2)
                    {
                        Debug.Log("Time threshold reached, marking as answered incorrectly.");
                        NotGoodAnswered(termdata.term, key);
                    }
                    else
                    {
                        float enoughtime = (float)(requiretime2 - lefttime.TotalSeconds);
                        StartCoroutine(WaiterLoad2(termdata.term, key, enoughtime));
                    }
                }
            }
            if (key.StartsWith("NotCorrectAnswer1_"))
            {
                string term = PlayerPrefs.GetString(key);
                TermData termdata = JsonUtility.FromJson<TermData>(term);
                /*SendNote(termdata.term, requiretime3);*/
                DateTime fixedtime;
                if (DateTime.TryParse(termdata.data, null, System.Globalization.DateTimeStyles.RoundtripKind, out fixedtime))
                {
                    TimeSpan lefttime = DateTime.Now - fixedtime;
                    if (lefttime.TotalSeconds >= requiretime3)
                    {
                        NotGoodAnswered1(termdata.term, key);
                    }
                    else
                    {
                        float enoughtime = (float)(requiretime3 - lefttime.TotalSeconds);
                        StartCoroutine(WaiterLoad2(termdata.term, key, enoughtime));
                    }
                }
            }
            if (key.StartsWith("NotCorrectAnswer2_"))
            {
                string term = PlayerPrefs.GetString(key);
                TermData termdata = JsonUtility.FromJson<TermData>(term);
                /*SendNote(termdata.term, requiretime4);*/
                DateTime fixedtime;
                if (DateTime.TryParse(termdata.data, null, System.Globalization.DateTimeStyles.RoundtripKind, out fixedtime))
                {
                    TimeSpan lefttime = DateTime.Now - fixedtime;
                    if (lefttime.TotalSeconds >= requiretime4)
                    {
                        NotGoodAnswered2(termdata.term, key);
                    }
                    else
                    {
                        float enoughtime = (float)(requiretime4 - lefttime.TotalSeconds);
                        StartCoroutine(WaiterLoad2(termdata.term, key, enoughtime));
                    }
                }
            }
        }

        PlayerPrefs.Save();
    }
    private IEnumerator WaiterLoad2(string term, string key, float wait)
    {
        yield return new WaitForSeconds(wait);
        if (key.StartsWith("NotCorrectAnswer_"))
        {
            NotGoodAnswered(term, key);
        }
        if (key.StartsWith("NotCorrectAnswer1_"))
        {
            NotGoodAnswered1(term, key);
        }
        if (key.StartsWith("NotCorrectAnswer2_"))
        {
            NotGoodAnswered2(term, key);
        }
    }
    private void NotGoodAnswered(string term, string key)
    {
        Addrepeat(term);
        Debug.Log("Will do");
        Debug.Log("TERM:" + term);
        string NotCorrectExistTerm2 = PlayerPrefs.GetString("2Again1");
        if (!string.IsNullOrEmpty(NotCorrectExistTerm2) && PlayerPrefs.GetInt("Note") == 0)
        {
            Debug.Log("ADDED TERM");
            NotCorrectRrepetition2 = NotCorrectExistTerm2 + ";" + term;
            int change = PlayerPrefs.GetInt("Note");
            change++;
            PlayerPrefs.SetInt("Note", change);
        }
        else if (PlayerPrefs.GetInt("Note") == 0)
        {
            Debug.Log("ADDED First TERM");
            NotCorrectRrepetition2 = term;
            int change = PlayerPrefs.GetInt("Note");
            change++;
            PlayerPrefs.SetInt("Note",change);
        }
        if (!string.IsNullOrEmpty(NotCorrectRrepetition2))
        {
            PlayerPrefs.SetString("2Again1", NotCorrectRrepetition2);
        }
        string NotCorrectExistTerm1 = PlayerPrefs.GetString("2Agains");
        string notcorrectkey2 = PlayerPrefs.GetString("NotCorrectsKeys2");
        if (!string.IsNullOrEmpty(NotCorrectExistTerm1) && !string.IsNullOrEmpty(notcorrectkey2))
        {
            NotCorrectRrepetition1 = NotCorrectExistTerm1 + ";" + term;
            NotCorrectkey2 = notcorrectkey2 + ";" + key;
        }
        else
        {
            NotCorrectRrepetition1 = term;
            NotCorrectkey2 = key;
        }
        PlayerPrefs.SetString("NotCorrectsKeys2", NotCorrectkey2);
        PlayerPrefs.SetString("2Agains", NotCorrectRrepetition1);
        PlayerPrefs.Save();
        Checker();
    }
    private void NotGoodAnswered1(string term, string key)
    {
        Addrepeat(term);
        int numer = PlayerPrefs.GetInt("Repeat3");
        int checker = PlayerPrefs.GetInt("Note3");
        string saver;
        string key3;
        if (numer == 3 && checker == 0)
        {
            saver = term;
            key3 = key;
            PlayerPrefs.SetInt("Note3", 1);
            PlayerPrefs.SetString("3Again1",saver);
            PlayerPrefs.SetString("3Again2", saver);
            PlayerPrefs.SetString("3Again3", saver);
            PlayerPrefs.SetString("NotCorrectsKeys3", key3);
        }
        else if (numer == 1 && checker == 0)
        {
            saver = term;
            key3 = key;
            PlayerPrefs.SetInt("Note3", 1);
            PlayerPrefs.SetString("3Again1", saver);
            PlayerPrefs.SetString("3Again3", saver);
            PlayerPrefs.SetString("NotCorrectsKeys3", key3);
        }
        else if (numer == 2 && checker == 0)
        {
            saver = term;
            key3 = key;
            PlayerPrefs.SetInt("Note3", 1);
            PlayerPrefs.SetString("3Again2", saver);
            PlayerPrefs.SetString("3Again3", saver);
            PlayerPrefs.SetString("NotCorrectsKeys3", key3);
        }
        else
        {
            Debug.Log("WAIT FOR NEXT");
        }
        PlayerPrefs.Save();
        Checker();
    }
    private void NotGoodAnswered2(string term, string key)
    {
        Addrepeat(term);
        int numer = PlayerPrefs.GetInt("Repeat4");
        int checker = PlayerPrefs.GetInt("Note4");
        string saver;
        string key4;
        if (numer == 7 && checker == 0)
        {
            saver = term;
            key4 = key;
            PlayerPrefs.SetInt("Note4", 1);
            PlayerPrefs.SetString("4Again1", saver);
            PlayerPrefs.SetString("4Again2", saver);
            PlayerPrefs.SetString("4Again3", saver);
            PlayerPrefs.SetString("4Again4", saver);
            PlayerPrefs.SetString("NotCorrectsKeys4", key4);
        }
        else if (numer == 1 && checker == 0)
        {
            saver = term;
            key4 = key;
            PlayerPrefs.SetInt("Note4", 1);
            PlayerPrefs.SetString("4Again1", saver);
            PlayerPrefs.SetString("4Again4", saver);
            PlayerPrefs.SetString("NotCorrectsKeys4", key4);
        }
        else if (numer == 2 && checker == 0)
        {
            saver = term;
            key4 = key;
            PlayerPrefs.SetInt("Note4", 1);
            PlayerPrefs.SetString("4Again2", saver);
            PlayerPrefs.SetString("4Again4", saver);
            PlayerPrefs.SetString("NotCorrectsKeys4", key4);
        }
        else if (numer == 4 && checker == 0)
        {
            saver = term;
            key4 = key;
            PlayerPrefs.SetInt("Note4", 1);
            PlayerPrefs.SetString("4Again3", saver);
            PlayerPrefs.SetString("4Again4", saver);
            PlayerPrefs.SetString("NotCorrectsKeys4", key4);
        }
        else if (numer == 3 && checker == 0)
        {
            saver = term;
            key4 = key;
            PlayerPrefs.SetInt("Note4", 1);
            PlayerPrefs.SetString("4Again1", saver);
            PlayerPrefs.SetString("4Again2", saver);
            PlayerPrefs.SetString("4Again4", saver);
            PlayerPrefs.SetString("NotCorrectsKeys4", key4);
        }
        else if (numer == 5 && checker == 0)
        {
            saver = term;
            key4 = key;
            PlayerPrefs.SetInt("Note4", 1);
            PlayerPrefs.SetString("4Again1", saver);
            PlayerPrefs.SetString("4Again3", saver);
            PlayerPrefs.SetString("4Again4", saver);
            PlayerPrefs.SetString("NotCorrectsKeys4", key4);
        }
        else if (numer == 6 && checker == 0)
        {
            saver = term;
            key4 = key;
            PlayerPrefs.SetInt("Note4", 1);
            PlayerPrefs.SetString("4Again2", saver);
            PlayerPrefs.SetString("4Again3", saver);
            PlayerPrefs.SetString("4Again4", saver);
            PlayerPrefs.SetString("NotCorrectsKeys4", key4);
        }
        else
        {
            Debug.Log("WAIT FOR NEXT");
        }
        PlayerPrefs.Save();
        Checker();
    }
    /*public async void SendNote(string term, float time)
    {
        string[] termers = term.Split(" ");
        string firstword = "";
        for (int j = 0; j < termers.Length; j++)
        {
            if (termers[j] == "це")
            {
                firstword = firstword.Trim();
                break;
            }
            firstword += termers[j] + " ";
        }
        await Notification.SendNotification("Memory", "Прийшов час повторити знову термін: " + firstword, time);
    }*/
    private List<string> PlayerPrefsKeys()
    {
        List<string> keys = new List<string>(PlayerPrefs.GetString("AllKeysCheck2").Split(";"));
        return keys;
    }
    private void Addrepeat(string term)
    {
        string existingTerms = PlayerPrefs.GetString("Terms");
        if (!PlayerPrefs.HasKey("Terms") || string.IsNullOrEmpty(existingTerms))
        {
            repetitions = term;
            PlayerPrefs.SetString("Terms", repetitions);
        }
        else 
        {
            List<string> lister = new List<string>(existingTerms.Split(";"));
            if (!lister.Contains(term))
            {
                repetitions = existingTerms + ";" + term;
                PlayerPrefs.SetString("Terms", repetitions);
            }
        }
        PlayerPrefs.Save();
    }
    private void Checker()
    {
        int updatingValue = PlayerPrefs.GetInt("Updating");
        bool hasRequireTime = PlayerPrefs.HasKey("RequireTime");
        string value2Again1 = PlayerPrefs.GetString("2Again1");
        string value1Again = PlayerPrefs.GetString("1Again");
        string value2Agains = PlayerPrefs.GetString("2Agains");
        string value11Again = PlayerPrefs.GetString("11Again");
        string value3_1Again = PlayerPrefs.GetString("3Again1");
        string value3_2Again = PlayerPrefs.GetString("3Again2");
        string value3_3Again = PlayerPrefs.GetString("3Again3");
        string value111Again = PlayerPrefs.GetString("111Again");
        string value4_1Again = PlayerPrefs.GetString("4Again1");
        string value4_2Again = PlayerPrefs.GetString("4Again2");
        string value4_3Again = PlayerPrefs.GetString("4Again3");
        string value4_4Again = PlayerPrefs.GetString("4Again4");
        string termsonweek = PlayerPrefs.GetString("Week0");
        bool check = PlayerPrefs.HasKey("Week0");
        remember.onClick.RemoveAllListeners();

        if (!string.IsNullOrEmpty(value2Again1))
        {
            remember.onClick.AddListener(Load1);
        }
        else if (!string.IsNullOrEmpty(value1Again) || !string.IsNullOrEmpty(value2Agains))
        {
            remember.onClick.AddListener(Load2);
        }
        else if (!string.IsNullOrEmpty(value3_1Again))
        {
            remember.onClick.AddListener(Load1);
        }
        else if (!string.IsNullOrEmpty(value3_2Again))
        {
            remember.onClick.AddListener(Load2);
        }
        else if (!string.IsNullOrEmpty(value3_3Again) || !string.IsNullOrEmpty(value11Again))
        {
            remember.onClick.AddListener(Load3);
        }
        else if (!string.IsNullOrEmpty(value4_1Again))
        {
            remember.onClick.AddListener(Load1);
        }
        else if (!string.IsNullOrEmpty(value4_2Again))
        {
            remember.onClick.AddListener(Load2);
        }
        else if (!string.IsNullOrEmpty(value4_3Again))
        {
            remember.onClick.AddListener(Load3);
        }
        else if (!string.IsNullOrEmpty(value4_4Again) || !string.IsNullOrEmpty(value111Again))
        {
            remember.onClick.AddListener(Load4);
        }
        else if ((!hasRequireTime && updatingValue < 3 && !string.IsNullOrEmpty(termsonweek)) || (updatingValue < 3 && !check))
        {
            remember.onClick.AddListener(Load1);
        }
        else if (updatingValue > 2 || hasRequireTime || string.IsNullOrEmpty(termsonweek))
        {
            remember.onClick.AddListener(Message);
        }
        else
        {
            remember.onClick.AddListener(MessageEnd);
        }
    }
    public void Message()
    {
        StartCoroutine(Error());
    }
    public void MessageEnd()
    {
        StartCoroutine(Ender());
    }
    private IEnumerator Error()
    {
        mes.text = "Очікуй повторень!";
        mes.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        mes.gameObject.SetActive(false);
    }
    private IEnumerator Ender()
    {
        mes.text = "Все вже повторено!";
        mes.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        mes.gameObject.SetActive(false);
    }
    public void UpTime()
    {
        PlayerPrefs.DeleteKey("Week0");
        PlayerPrefs.DeleteKey("Week7");
        int num = PlayerPrefs.GetInt("Updating");
        num++;
        PlayerPrefs.SetInt("Updating", num);
        PlayerPrefs.Save();
        Weeker();
    }
    public void UpTime1()
    {
        Debug.Log("TimeEnd");
        PlayerPrefs.DeleteKey("RequireTime");
        PlayerPrefs.Save();
        Checker();
    }
    public void Load1()
    {
        SceneManager.LoadScene("Words");
    }
    public void Load2()
    {
        SceneManager.LoadScene("Words1");
    }
    public void Load3()
    {
        SceneManager.LoadScene("Words2");
    }
    public void Load4()
    {
        SceneManager.LoadScene("Words3");
    }
    public void Terms()
    {
        SceneManager.LoadScene("Terms");
    }

}
