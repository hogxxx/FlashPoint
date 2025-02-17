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
    public static int updatevalue;
    public static int chooser;
    public static string week;
    void Start()
    {
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
        days = FileManager.LoadTerms();
        if (days.Count != 0)
        {
            PlayerPrefs.SetString("Day0", days[0]);
            PlayerPrefs.Save();
            termsDay = days;
        }
        if (termsDay.Contains(""))
        {
            termsDay.Remove("");
        }
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
}
