using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
public class Learn : MonoBehaviour
{
    // Start is called before the first frame update
    private List<List<string>> weeks;
    public TextMeshProUGUI main;
    public TextMeshProUGUI words;
    public RectTransform wordsarea;
    public RectTransform content;
    private List<string> terms1 = new List<string>();
    private List<string> terms2 = new List<string>();
    private int updatevalue;
    private int chooser;
    void Start()
    {
        weeks = FileManager.LoadTerms();
        updatevalue = PlayerPrefs.GetInt("Updating");
        chooser = PlayerPrefs.GetInt("Chooser");
        if (!PlayerPrefs.HasKey("Week0") && updatevalue < chooser)
        {
            Numbers();
        }
        terms1 = new List<string>(PlayerPrefs.GetString("Week0").Split(";"));
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
        foreach (var term in terms2)
        {
            terms1.Add(term);
        }
        Loads();
    }
    private void Numbers()
    {
        string termins = string.Join(";", weeks[updatevalue]);
        PlayerPrefs.SetString("Week0", termins);
        PlayerPrefs.Save();
    }
    private void Loads()
    {
        if (updatevalue >= chooser && terms1.Count == 1)
        {
            main.gameObject.SetActive(false);
            words.text = "Повторень на тиждень немає!";
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
            for (int i = 0; i < terms1.Count; i++)
            {
                string firstword = "";
                string[] termers = terms1[i].Split(" ");
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
                if (i == terms1.Count - 1)
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
