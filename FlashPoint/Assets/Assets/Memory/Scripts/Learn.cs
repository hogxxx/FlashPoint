using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System;
public class Learn : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<List<string>> weeks;
    public TextMeshProUGUI main;
    public TextMeshProUGUI words;
    public RectTransform wordsarea;
    public RectTransform content;
    public static List<string> terms1 = new List<string>();
    private List<string> terms2 = new List<string>();
    public static List<string> termsDay = new List<string>{""};
    public static int updatevalue;
    public static int chooser;
    public static List<int> days = new List<int>(new int[7]);
    private float requiretime1 = 86400f;
    public static string week;
    void Start()
    {
        Generating();
        Oneday();
        string terms = PlayerPrefs.GetString("Terms");
        string[] spliter = terms.Split(";");
        if (spliter.Length > 1)
        {
            terms2 = new List<string>(terms.Split(";"));
        }
        else if (!string.IsNullOrEmpty(terms) && spliter.Length == 1)
        {
            terms2 = new List<string>()
            {
                terms
            };
        }
        string terms1 = PlayerPrefs.GetString("Day0");
        Debug.Log(terms1);
        string[] spliter1 = terms1.Split(";");
        if (spliter1.Length > 1)
        {
            termsDay = new List<string>(terms1.Split(";"));
        }
        else if (!string.IsNullOrEmpty(terms) && spliter.Length == 1)
        {
            termsDay = new List<string>()
            {
                terms1
            };
        }
        else if(string.IsNullOrEmpty(terms1))
        {
            termsDay = new List<string> { "" };
        }
        foreach (var term in terms2)
        {
            if (!termsDay.Contains(term))
            {
                termsDay.Add(term);
            }
        }
        Debug.Log(string.Join(";", termsDay));
        Loads();
    }
    public static void Generating()
    {
        weeks = FileManager.LoadTerms();
        updatevalue = PlayerPrefs.GetInt("Updating");
        chooser = PlayerPrefs.GetInt("Chooser");
        if (!PlayerPrefs.HasKey("Week0") && updatevalue < chooser)
        {
            Numbers();
            terms1 = new List<string>(PlayerPrefs.GetString("Week0").Split(";"));
            int termers = 0;
            foreach (var term in terms1)
            {
                termers++;
            }
            int count1 = termers / 6;
            int count2 = termers % 6;
            if (count1 != 0 && count2 != 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    days[i] = count1;
                    if (count2 != 0)
                    {
                        days[i] += 1;
                        count2--;
                    }
                }
                days[6] = 0;
            }
            else if (count1 == 0)
            {
                for (int i = 0; i < days.Count; i++)
                {
                    if (count2 != 0)
                    {
                        days[i] = 1;
                        count2--;
                    }
                    else
                    {
                        days[i] = 0;
                    }
                }
            }
            else if (count2 == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    days[i] = count1;
                }
                days[6] = 0;
            }
        }
        week = PlayerPrefs.GetString("Week0");
        if (!string.IsNullOrEmpty(week) && !PlayerPrefs.HasKey("RequireTime"))
        {
            terms1 = new List<string>(week.Split(";"));
            int num = PlayerPrefs.GetInt("DayNum");
            if (num == 0)
            {
                int num1 = days[num];
                if (num1 != 0)
                {
                    termsDay = terms1.Take(num1).ToList();
                    PlayerPrefs.SetInt("LastNum", days[num]);
                }
            }
            else
            {
                int numlast = PlayerPrefs.GetInt("LastNum");
                int num1 = days[num];
                if (num1 != 0)
                {
                    termsDay = terms1.GetRange(numlast, num1);
                    PlayerPrefs.SetInt("LastNum", days[num]);
                }
            }
            if (termsDay.Count == 1)
            {
                string term = termsDay[0];
                PlayerPrefs.SetString("Day0", term);
            }
            else
            {
                string termins = string.Join(";", termsDay);
                PlayerPrefs.SetString("Day0", termins);
            }
            PlayerPrefs.Save();
        }
        if (termsDay.Contains(""))
        {
            termsDay.Remove("");
        }
    }
    public static void Numbers()
    {
        string termins = string.Join(";", weeks[updatevalue]);
        PlayerPrefs.SetString("Week0", termins);
        PlayerPrefs.Save();
    }
    private void Loads()
    {
        if (updatevalue >= chooser || termsDay.Count == 0 || termsDay.Contains(""))
        {
            main.gameObject.SetActive(false);
            words.text = "Повторень на день немає!";
            words.alignment = TextAlignmentOptions.Center;
            float newheight = words.preferredHeight;
            wordsarea.sizeDelta = new Vector2(wordsarea.sizeDelta.x, newheight);
            content.pivot = new Vector2(0.5f, 0.5f);
            content.anchorMin = new Vector2(0.5f, 0.5f);
            content.anchorMax = new Vector2(0.5f, 0.5f);
            content.sizeDelta = new Vector2(content.sizeDelta.x, newheight);
        }
        else
        {
            for (int i = 0; i < termsDay.Count; i++)
            {
                string firstword = "";
                string[] termers = termsDay[i].Split(" ");
                for (int j = 0;j < termers.Length; j++)
                {
                    if (termers[j] == "це")
                    {
                        firstword = firstword.Trim();
                        break;
                    }
                    else if (!string.IsNullOrEmpty(termers[j]))
                    {
                        firstword += termers[j] + " ";
                    }
                }
                words.alignment = TextAlignmentOptions.TopLeft;
                if (i == termsDay.Count - 1)
                {
                    words.text += firstword + "." + "\n";
                }
                else if (!string.IsNullOrEmpty(firstword))
                {
                    words.text += firstword + ";" + "\n";
                }
                float newheight = words.preferredHeight;
                wordsarea.sizeDelta = new Vector2(wordsarea.sizeDelta.x, newheight);
                content.pivot = new Vector2(0f, 1f);
                content.anchorMin = new Vector2(0f, 1f);
                content.anchorMax = new Vector2(0f, 1f);
                content.sizeDelta = new Vector2(content.sizeDelta.x, newheight);
            }
        }
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
        else if(updatevalue < chooser)
        {
            PlayerPrefs.SetString("RequireTime", System.DateTime.Now.ToString("o"));
            PlayerPrefs.Save();
            Oneday();
        }
    }
    public void UpTime1()
    {
        PlayerPrefs.DeleteKey("RequireTime");
        Generating();
        PlayerPrefs.SetString("RequireTime", System.DateTime.Now.ToString("o"));
        Oneday();
        int num = PlayerPrefs.GetInt("DayNum");
        num++;
        if (num >= 6)
        {
            PlayerPrefs.SetInt("DayNum", num);
        }
        PlayerPrefs.Save();
    }
}
