using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Generate1 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<string> distractingWords = new List<string>();
    private string Term;
    private List<string> Terms1 = new List<string>();
    private List<string> Terms2 = new List<string>();
    private List<string> Termsagain3 = new List<string>();
    private List<string> Termsagain4 = new List<string>();
    private List<string> RepetitionsEnd = new List<string>();
    private List<string> CorrectsKeys1 = new List<string>();
    private List<string> NotCorrectsKeys2 = new List<string>();
    private List<string> deleteskeys = new List<string>();
    private string sentence;
    private List<string> words;
    public GameObject area;
    private Vector2[] positions =
    {
        new Vector2(-5.93f, 3.79f),
        new Vector2(0.07f, 3.79f),
        new Vector2(6.07f, 3.79f),
        new Vector2(-5.93f, 2.19f),
        new Vector2(0.07f, 2.19f),
        new Vector2(6.07f, 2.19f),
        new Vector2(-5.93f, 0.59f),
        new Vector2(0.07f, 0.59f),
        new Vector2(6.07f, 0.59f),
    };
    public List<Image> blocks = new List<Image>(11);
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[11];
    private int counts;
    private int counts1;
    private List<GameObject> dropareas = new List<GameObject>();
    private List<string> ordertexts;
    private List<string> worders;
    private List<string> worders1;
    private bool isCorrect = true;
    public GameObject panel;
    public TextMeshProUGUI mesage;
    public TextMeshProUGUI correctterm;
    public TextMeshProUGUI correct;
    public Button backer;
    private string agains_2;
    private string agains_1;
    private string termsagain3;
    private string termsagain4;
    private string savechecker;
    private int sumer;
    private int sumer1;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        agains_2 = PlayerPrefs.GetString("2Agains");
        agains_1 = PlayerPrefs.GetString("1Again");
        CorrectsKeys1 = new List<string>(PlayerPrefs.GetString("CorrectsKeys1").Split(";"));
        NotCorrectsKeys2 = new List<string>(PlayerPrefs.GetString("NotCorrectsKeys2").Split(";"));
        Terms1 = new List<string>(agains_1.Split(";"));
        Terms2 = new List<string>(agains_2.Split(";"));
        RepetitionsEnd = new List<string>(PlayerPrefs.GetString("Terms").Split(";"));
        Terms1 = DelCopy.RemoveDuplicates(Terms1);
        Terms2 = DelCopy.RemoveDuplicates(Terms2);
        CorrectsKeys1 = DelCopy.RemoveDuplicates(CorrectsKeys1);
        NotCorrectsKeys2 = DelCopy.RemoveDuplicates(NotCorrectsKeys2);
        termsagain3 = PlayerPrefs.GetString("3Again2");
        Termsagain3 = new List<string>(termsagain3.Split(";"));
        termsagain4 = PlayerPrefs.GetString("4Again2");
        Termsagain4 = new List<string>(termsagain4.Split(";"));
        if (!string.IsNullOrEmpty(agains_2))
        {
            sentence = Terms2[0];
            Term = Terms2[0];
        }
        else if (!string.IsNullOrEmpty(agains_1))
        {
            sentence = Terms1[0];
            Term = Terms1[0];
        }
        else if (!string.IsNullOrEmpty(termsagain3))
        {
            sentence = Termsagain3[0];
            Term = Termsagain3[0];
        }
        else if (!string.IsNullOrEmpty(termsagain4))
        {
            sentence = Termsagain4[0];
            Term = Termsagain4[0];
        }
        words = new List<string>(sentence.Split(" "));
        OrderObject.CheckTerm(words[0]);
        distractingWords = DistructWords.distructwords;
        Debug.Log(distractingWords.Count);
        worders = new List<string>(words);
        counts = words.Count;
        counts1 = counts + 2;
        worders1 = new List<string>(worders);
        for (int i = worders1.Count; i < counts1; i++)
        {
            bool good = true;
            int rand = Random.Range(0, distractingWords.Count);
            foreach (string word in worders1)
            {
                if (distractingWords[rand].ToLower() == word.ToLower())
                {
                    good = false;
                    i--;
                    break;
                }
            }
            if (good)
            {
                worders1.Add(distractingWords[rand].ToLower());
            }
        }
        sumer = PlayerPrefs.GetInt("Repeat3");
        sumer1 = PlayerPrefs.GetInt("Repeat4");
        Generated();
    }
    private void Generated()
    {
        for (int i = 0; i < counts; i++)
        {
            GameObject areas = Instantiate(area, GameObject.Find("Container").transform);
            RectTransform rectTransform = areas.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = positions[i];
            dropareas.Add(areas);
        }
        for (int i = 0; i < counts1; i++)
        {
            int randword = Random.Range(0, worders1.Count);
            texts[i].text = worders1[randword];
            worders1.RemoveAt(randword);
            blocks[i].gameObject.SetActive(true);
        }
    }
    public void Check()
    {
        ordertexts = new List<string>();
        List<Image> blocksCopy = new List<Image>(blocks); // Копия списка blocks

        foreach (GameObject drop1 in dropareas)
        {
            RectTransform droper = drop1.GetComponent<RectTransform>();

            for (int i = 0; i < blocksCopy.Count; i++)
            {
                RectTransform blocker = blocksCopy[i].GetComponent<RectTransform>();

                if (RectOverlaps(droper, blocker))
                {
                    TextMeshProUGUI blocktext = blocksCopy[i].GetComponentInChildren<TextMeshProUGUI>();

                    if (blocktext != null)
                    {
                        ordertexts.Add(blocktext.text);
                    }

                    blocksCopy.RemoveAt(i); // Удаляем блок из копии списка
                    break;
                }
            }
        }

        if (ordertexts.Count == dropareas.Count)
        {
            isCorrect = true;

            for (int i = 0; i < dropareas.Count; i++)
            {
                if (ordertexts[i] != worders[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                Correct();
            }
            else
            {
                NotCorrect();
            }
        }
    }

    private bool RectOverlaps(RectTransform droper, RectTransform blocker)
    {
        Rect rect1 = new Rect
        (
        droper.position.x - droper.rect.width * droper.lossyScale.x / 2,
        droper.position.y - droper.rect.height * droper.lossyScale.y / 2,
        droper.rect.width * droper.lossyScale.x,
        droper.rect.height * droper.lossyScale.y
        );

        Rect rect2 = new Rect
        (
        blocker.position.x - blocker.rect.width * blocker.lossyScale.x / 2,
        blocker.position.y - blocker.rect.height * blocker.lossyScale.y / 2,
        blocker.rect.width * blocker.lossyScale.x,
        blocker.rect.height * blocker.lossyScale.y
        );
        return rect1.Overlaps(rect2);
    }
    private void Correct()
    {
        panel.gameObject.SetActive(true);
        mesage.text = "Правильно!";
        mesage.color = new Color(53f / 255f, 255f / 255f, 0f / 255f);
        backer.onClick.RemoveAllListeners();
        backer.onClick.AddListener(Continue);
    }
    private void NotCorrect()
    {
        panel.gameObject.SetActive(true);
        correct.gameObject.SetActive(true);
        correctterm.text = sentence;
        correctterm.gameObject.SetActive(true);
        mesage.text = "Не правильно!";
        mesage.color = new Color(255f / 255f, 59f / 255f, 0f / 255f);
        backer.onClick.RemoveAllListeners();
        backer.onClick.AddListener(Add);
    }

    private void Continue()
    {
        if (!string.IsNullOrEmpty(agains_2) || !string.IsNullOrEmpty(agains_1))
        {
            if (sumer == 0)
            {
                AddCorrect();
            }
            else
            {
                AddNotCorrect();
            }
            deleteskeys = new List<string>(PlayerPrefs.GetString("AllKeysCheck2").Split(";"));
            SaveString();
        }
        else if (!string.IsNullOrEmpty(termsagain3))
        {
            Termsagain3.RemoveAt(0);
            string termstring = string.Join(";", Termsagain3);
            PlayerPrefs.SetString("3Again2", termstring);
        }
        else if (!string.IsNullOrEmpty(termsagain4))
        {
            Termsagain4.RemoveAt(0);
            string termstring = string.Join(";", Termsagain4);
            PlayerPrefs.SetString("4Again2", termstring);
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }
    private void Add()
    {
        if (!string.IsNullOrEmpty(agains_2) || !string.IsNullOrEmpty(agains_1))
        {
            AddNotCorrect();
            deleteskeys = new List<string>(PlayerPrefs.GetString("AllKeysCheck2").Split(";"));
            SaveString();
            int numer = sumer;
            numer += 2;
            PlayerPrefs.SetInt("Repeat3", numer);
            Debug.Log("YES");
        }
        else if (!string.IsNullOrEmpty(termsagain3))
        {
            Termsagain3.RemoveAt(0);
            string termstring = string.Join(";", Termsagain3);
            PlayerPrefs.SetString("3Again2", termstring);
            int numer = sumer1;
            numer += 2;
            PlayerPrefs.SetInt("Repeat4", numer);
        }
        else if (!string.IsNullOrEmpty(termsagain4))
        {
            Termsagain4.RemoveAt(0);
            string termstring = string.Join(";", Termsagain4);
            PlayerPrefs.SetString("4Again2", termstring);
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }
    private void AddCorrect()
    {
        Debug.Log("YEBOY");
        TermData termin = new TermData
        {
            term = Term,
            data = System.DateTime.Now.ToString("o")
        };
        string converter = JsonUtility.ToJson(termin);
        string key = "CorrectAnswer1_" + System.DateTime.Now.Ticks;
        AddCheck(key);
        PlayerPrefs.SetString(key, converter);
        PlayerPrefs.Save();
    }
    private void AddNotCorrect()
    {
        TermData termin = new TermData
        {
            term = Term,
            data = System.DateTime.Now.ToString("o")
        };
        string converter = JsonUtility.ToJson(termin);
        string key = "NotCorrectAnswer1_" + System.DateTime.Now.Ticks;
        AddCheck(key);
        PlayerPrefs.SetString(key, converter);
        PlayerPrefs.Save();
    }
    private void AddCheck(string key)
    {
        string existkey = PlayerPrefs.GetString("AllKeysCheck2");
        if (!string.IsNullOrEmpty(existkey))
        {
            savechecker = existkey + ";" + key;
        }
        else if (string.IsNullOrEmpty(existkey))
        {
            savechecker = key;
        }
        PlayerPrefs.SetString("AllKeysCheck2", savechecker);
    }
    private void SaveString()
    {
        if (string.IsNullOrEmpty(agains_2))
        {
            if (RepetitionsEnd.Contains(Terms1[0]))
            {
                RepetitionsEnd.Remove(Terms1[0]);
            }
            string termend1 = string.Join(";", RepetitionsEnd);
            PlayerPrefs.SetString("Terms", termend1);
            if (deleteskeys.Contains(CorrectsKeys1[0]))
            {
                deleteskeys.Remove(CorrectsKeys1[0]);
            }
            string termdel1 = string.Join(";", deleteskeys);
            Debug.Log("CHANGE:" + termdel1);
            PlayerPrefs.SetString("AllKeysCheck2", termdel1);
            Terms1.RemoveAt(0);
            CorrectsKeys1.RemoveAt(0);
            string termstring1 = string.Join(";", Terms1);
            string termkey1 = string.Join(";", CorrectsKeys1);
            PlayerPrefs.SetString("CorrectsKeys1", termkey1);
            PlayerPrefs.SetString("1Again", termstring1);
        }
        else
        {
            if (RepetitionsEnd.Contains(Terms2[0]))
            {
                RepetitionsEnd.Remove(Terms2[0]);
            }
            string termend2 = string.Join(";", RepetitionsEnd);
            PlayerPrefs.SetString("Terms", termend2);
            if (deleteskeys.Contains(NotCorrectsKeys2[0]))
            {
                deleteskeys.Remove(NotCorrectsKeys2[0]);
            }
            string termdel2 = string.Join(";", deleteskeys);
            Debug.Log("CHANGE:" + termdel2);
            PlayerPrefs.SetString("AllKeysCheck2", termdel2);
            PlayerPrefs.SetInt("Note", 0);
            Terms2.RemoveAt(0);
            NotCorrectsKeys2.RemoveAt(0);
            string termstring2 = string.Join(";", Terms2);
            string termkey2 = string.Join(";", NotCorrectsKeys2);
            PlayerPrefs.SetString("NotCorrectsKeys2", termkey2);
            PlayerPrefs.SetString("2Agains", termstring2);
        }
        PlayerPrefs.Save();
    }
}
public class DelCopy
{
    public static List<string> RemoveDuplicates(List<string> listwithduplicates)
    {
        List<string> withoutduplicates = new List<string>();
        foreach (string item in listwithduplicates)
        {
            if(!withoutduplicates.Contains(item))
            {
                withoutduplicates.Add(item);
            }
        }
        return withoutduplicates;
    }
}