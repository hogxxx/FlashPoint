using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System;
public class Learn : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<string> days;
    public TextMeshProUGUI main;
    public TextMeshProUGUI words;
    public RectTransform wordsarea;
    public RectTransform content;
    public static List<string> terms1 = new List<string>();
    private List<string> terms2 = new List<string>();
    public static List<string> termsDay = new List<string>{""};
    public static string week;
    void Start()
    {
        string terms = PlayerPrefs.GetString("Terms");
        string[] spliter = terms.Split(";");
        if (spliter.Length > 1)
        {
            List<string> orderTerms = new List<string>(terms.Split(";"));
            foreach (var term in orderTerms)
            {
                terms2.Add("Повтори: " + term);
            }
        }
        else if (!string.IsNullOrEmpty(terms) && spliter.Length == 1)
        {
            terms2 = new List<string>()
            {
                "Повтори: " + terms
            };
        }
        string terms1 = PlayerPrefs.GetString("Day0");
        string[] spliter1 = terms1.Split(";");
        if (spliter1.Length > 1)
        {
            List<string> orderTerms = new List<string>(terms1.Split(";"));
            foreach (var term in orderTerms)
            {
                termsDay.Add("Повтори: " + term);
            }
        }
        else if (!string.IsNullOrEmpty(terms) && spliter.Length == 1)
        {
            termsDay = new List<string>()
            {
                "Повтори: " + terms1
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
        Loads();
    }
    public static void Generating()
    {
        days = FileManager.LoadTerms();
        if (days.Count != 0)
        {
            PlayerPrefs.SetString("Day0", days[0]);
            PlayerPrefs.Save();
            foreach (var day in days)
            {
                if (!termsDay.Contains("Повтори: " + day))
                {
                    termsDay.Add("Повтори: " + day);
                }
            }
        }
        if (termsDay.Contains(""))
        {
            termsDay.Remove("");
        }
    }
    public static void AddScheme()
    {
        termsDay.Insert(0, "Заповни схему це");
    }
    public static void DelScheme()
    {
        if (termsDay.Contains("Заповни схему це"))
        {
            termsDay.Remove("Заповни схему це");
        }  
    }
    private void Loads()
    {
        if (termsDay.Count == 0 || termsDay.Contains(""))
        {
            main.gameObject.SetActive(false);
            words.text = "Завдань на день немає!";
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
            main.gameObject.SetActive(true);
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
}
