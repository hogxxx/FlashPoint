using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Generate : MonoBehaviour
{
    // Start is called before the first frame update
    private List<string> Terms = new List<string>();
    private List<string> Termsagain = new List<string>();
    private List<string> Termsagain3 = new List<string>();
    private List<string> Termsagain4 = new List<string>();
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
    public List<Image> blocks = new List<Image>(9);
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[9];
    private int counts;
    private List<GameObject> dropareas = new List<GameObject>();
    private List<string> ordertexts;
    private List<string> worders;
    private bool isCorrect = true;
    public GameObject panel;
    public TextMeshProUGUI mesage;
    public TextMeshProUGUI correctterm;
    public TextMeshProUGUI correct;
    public Button backer;
    private string termsagain3;
    private string termsagain4;
    private string savecheker;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Terms = new List<string>(PlayerPrefs.GetString("Day0").Split(";"));
        Termsagain = new List<string>(PlayerPrefs.GetString("2Again1").Split(";"));
        termsagain3 = PlayerPrefs.GetString("3Again1");
        Termsagain3 = new List<string>(termsagain3.Split(";"));
        termsagain4 = PlayerPrefs.GetString("4Again1");
        Termsagain4 = new List<string>(termsagain4.Split(";"));
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("2Again1")))
        {
            sentence = Termsagain[0];
        }
        else if (!string.IsNullOrEmpty(termsagain3))
        {
            sentence = Termsagain3[0];
        }
        else if (!string.IsNullOrEmpty(termsagain4))
        {
            sentence = Termsagain4[0];
        }
        else
        {
            sentence = Terms[0];
        }
        words = new List<string>(sentence.Split(" "));
        worders = new List<string>(words);
        counts = words.Count;
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
        for (int i = 0; i < counts; i++)
        {
            int randword = Random.Range(0, words.Count);
            texts[i].text = words[randword];
            words.RemoveAt(randword);
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
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("2Again1")))
        {
            SaveString();
            Debug.Log("ПОВТОР");
        }
        else if (!string.IsNullOrEmpty(termsagain3))
        {
            Termsagain3.RemoveAt(0);
            string termstring = string.Join(";", Termsagain3);
            PlayerPrefs.SetString("3Again1", termstring);
        }
        else if (!string.IsNullOrEmpty(termsagain4))
        {
            Termsagain4.RemoveAt(0);
            string termstring = string.Join(";", Termsagain4);
            PlayerPrefs.SetString("4Again1", termstring);
        }
        else
        {
            Debug.Log("Метод AddCorrect вызван.");
            AddCorrect();
            Terms.RemoveAt(0);
            ChangeList();
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main");
    }
    private void Add()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("2Again1")))
        {
            SaveString();
            int numer = PlayerPrefs.GetInt("Repeat3");
            numer++;
            PlayerPrefs.SetInt("Repeat3", numer);
            Debug.Log("ПОВТОР");
        }
        else if(!string.IsNullOrEmpty(termsagain3))
        {
            Termsagain3.RemoveAt(0);
            string termstring = string.Join(";", Termsagain3);
            PlayerPrefs.SetString("3Again1", termstring);
            int numer = PlayerPrefs.GetInt("Repeat4");
            numer++;
            PlayerPrefs.SetInt("Repeat4", numer);
            Debug.Log("ПОВТОР3");
        }
        else if (!string.IsNullOrEmpty(termsagain4))
        {
            Termsagain4.RemoveAt(0);
            string termstring = string.Join(";", Termsagain4);
            PlayerPrefs.SetString("4Again1", termstring);
        }
        else
        {
            Debug.Log("Метод AddNotCorrect вызван.");
            AddNotCorrect();
            Terms.RemoveAt(0);
            ChangeList();
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main");
    }

    private void AddCorrect()
    {
        TermData termin = new TermData
        {
            term = Terms[0],
            data = System.DateTime.Now.ToString("o")
        };
        string converter = JsonUtility.ToJson(termin);
        string key = "CorrectAnswer_" + System.DateTime.Now.Ticks;
        AddCheck(key);
        PlayerPrefs.SetString(key, converter);
        PlayerPrefs.Save();

        // Отладочные сообщения
        Debug.Log("Сохранен правильный ответ:");
        Debug.Log("Ключ: " + key);
        Debug.Log("Значение: " + converter);
    }

    private void AddNotCorrect()
    {
        TermData termin = new TermData
        {
            term = Terms[0],
            data = System.DateTime.Now.ToString("o")
        };
        string converter = JsonUtility.ToJson(termin);
        string key = "NotCorrectAnswer_" + System.DateTime.Now.Ticks;
        AddCheck(key);
        PlayerPrefs.SetString(key, converter);
        PlayerPrefs.Save();

        // Отладочные сообщения
        Debug.Log("Сохранен неправильный ответ:");
        Debug.Log("Ключ: " + key);
        Debug.Log("Значение: " + converter);
    }
    private void AddCheck(string key)
    {
        string existkey = PlayerPrefs.GetString("AllKeysCheck2");
        if (!string.IsNullOrEmpty(existkey))
        {
            savecheker = existkey + ";" + key;
        }
        else if (string.IsNullOrEmpty(existkey))
        {
            savecheker = key;
        }
        PlayerPrefs.SetString("AllKeysCheck2", savecheker);
    }
    private void ChangeList()
    {
        string termins = string.Join(";", Terms);
        PlayerPrefs.SetString("Day0", termins);
        PlayerPrefs.Save();
    }
    private void SaveString()
    {
        Termsagain.RemoveAt(0);
        string termstring = string.Join(";", Termsagain);
        PlayerPrefs.SetString("2Again1", termstring);
        PlayerPrefs.Save();
    }
}
[System.Serializable]
public class TermData
{
    public string term;
    public string data;
}
