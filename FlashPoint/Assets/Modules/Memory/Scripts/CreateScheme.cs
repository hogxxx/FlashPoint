using System.IO;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;
using Unity.VisualScripting;
public class CreateScheme : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Image> blocks = new List<Image>(9);
    public List<Image>  schemes = new List<Image>(9);
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[9];
    public GameObject area;
    private Vector2[] positions =
    {
        new Vector2(-8.27f, 3.6476f),
        new Vector2(-4.87f, 3.6476f),
        new Vector2(-1.47f, 3.6476f),
        new Vector2(1.93f, 3.6476f),
        new Vector2(5.33f, 3.6476f),
        new Vector2(8.73f, 3.6476f),
        new Vector2(-8.27f, 2.1961f),
        new Vector2(-4.87f, 2.1961f),
        new Vector2(-1.47f, 2.1961f),
        new Vector2(1.93f, 2.1961f),
        new Vector2(5.33f, 2.1961f),
        new Vector2(8.73f, 2.1961f),
        new Vector2(-8.27f, 0.74456f),
        new Vector2(-4.87f, 0.74456f),
        new Vector2(-1.47f, 0.74456f),
        new Vector2(1.93f, 0.74456f),
        new Vector2(5.33f, 0.74456f),
        new Vector2(8.73f, 0.74456f),
    };
    private List<List<string>> order1 = new List<List<string>>()
    {
        new List<string>
        {
            "гальванічний елемент",
            "з’єднання провідників",
            "вимикач",
            "електрична лампа",
            "плавкий запобіжник",
            "реостат"
        }
    };
    public List<Sprite> scheme1 = new List<Sprite>();
    private List<List<Sprite>> order2;
    private List<GameObject> dropareas = new List<GameObject>();
    private int count;
    private int numer;
    private bool Correct1 = true;
    public GameObject panel;
    public TextMeshProUGUI mesage;
    public Button backer;
    public List<Sprite> answers = new List<Sprite>();
    private Vector2[] positions1 =
    {
        new Vector2(-5.5f, 2.3708f),
        new Vector2(-3.3f, 2.3708f),
        new Vector2(-1.1f, 2.3708f),
        new Vector2(1.1f, 2.3708f),
        new Vector2(3.3f, 2.3708f),
        new Vector2(5.5f, 2.3708f),
        new Vector2(-5.5f, 1.26f),
        new Vector2(-3.3f, 1.26f),
        new Vector2(-1.1f, 1.26f),
        new Vector2(1.1f, 1.26f),
        new Vector2(3.3f, 1.26f),
        new Vector2(5.5f, 1.26f),
        new Vector2(-5.5f, 0.1492f),
        new Vector2(-3.3f, 0.1492f),
        new Vector2(-1.1f, 0.1492f),
        new Vector2(1.1f, 0.1492f),
        new Vector2(3.3f, 0.1492f),
        new Vector2(5.5f, 0.1492f),
    };
    public List<Image> blocks1 = new List<Image>(9);
    public List<Image> schemes1 = new List<Image>(9);
    public TextMeshProUGUI[] texts1 = new TextMeshProUGUI[9];
    public GameObject area1;
    private List<Sprite> extra = new List<Sprite>();
    void Start()
    {
        order2 = new List<List<Sprite>>(){scheme1};
        GenerateTask();
    }
    private void GenerateTask()
    {
        numer = PlayerPrefs.GetInt("NumScheme");
        List<Sprite> ordered = order2[numer];
        extra = new List<Sprite>(order2[numer]);
        List<string> messages = order1[numer];
        count = ordered.Count;
        int count2 = count * 2;
        for (int i = 0; i < count2; i++)
        {
            GameObject areas = Instantiate(area, GameObject.Find("Container1").transform);
            RectTransform rectTransform = areas.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = positions[i];
            dropareas.Add(areas);
        }
        for (int i = 0;i < count;i++)
        {
            blocks[i].gameObject.SetActive(true);
            blocks[i].transform.SetAsLastSibling();
            texts[i].text = messages[i];
            RectTransform blockRect = blocks[i].GetComponent<RectTransform>();
            if (i != 0)
            {
                blockRect.anchoredPosition = positions[i * 2];
            }
            else
            {
                blockRect.anchoredPosition = positions[i];
            }
            var blockact = blocks[i].GetComponent<DragHandler>();
            if (blockact != null)
            {
                blockact.enabled = false;
            }
        }
        List<Sprite> sprites = ordered;
        int count1 = sprites.Count;
        for (int i = 0;i < count; i++)
        {
            schemes[i].gameObject.SetActive(true);
            int randnum = Random.Range(0,count1);
            schemes[i].sprite = sprites[randnum];
            sprites.RemoveAt(randnum);
            count1--;
        }
    }
    public void Check()
    {
        int number = 0;
        for (int i = 0; i < dropareas.Count; i++)
        {
            RectTransform droper = dropareas[i].GetComponent<RectTransform>();
            foreach (var scheme in schemes)
            {
                RectTransform schemer = scheme.GetComponent<RectTransform>();
                if (RectOverlaps(schemer,droper))
                {
                    number++;
                }
            }
            if (i == 1 || i % 2 != 0)
            {
                if (i == 1)
                {
                    RectTransform im1 = schemes[i - 1].GetComponent<RectTransform>();
                    if (RectOverlaps(droper, im1))
                    {
                        Correct1 = true;
                    }
                    else
                    {
                        Correct1 = false;
                    }
                }
                else
                {
                    int num = i / 2;
                    RectTransform im2 = schemes[num].GetComponent<RectTransform>();
                    if (RectOverlaps(droper, im2))
                    {
                        Correct1 = true;
                    }
                    else
                    {
                        Correct1 = false;
                    }
                }
            }
        }
        if (Correct1 && number == count)
        {
            Correct();
        }
        else if (number == count)
        {
            NotCorrect();
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
        GenerateAnswer();
        backer.onClick.RemoveAllListeners();
        backer.onClick.AddListener(Continue);
    }
    private void NotCorrect()
    {
        panel.gameObject.SetActive(true);
        mesage.text = "Не правильно!";
        mesage.color = new Color(255f / 255f, 59f / 255f, 0f / 255f);
        GenerateAnswer();
        backer.onClick.RemoveAllListeners();
        backer.onClick.AddListener(Continue);
    }
    private void GenerateAnswer()
    {
        List<Sprite> ordered = order2[numer];
        List<string> messages = order1[numer];
        int count2 = count * 2;
        for (int i = 0; i < count2; i++)
        {
            GameObject areas = Instantiate(area1, GameObject.Find("Container2").transform);
            RectTransform rectTransform = areas.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = positions1[i];
        }
        for (int i = 0; i < count; i++)
        {
            blocks1[i].gameObject.SetActive(true);
            blocks1[i].transform.SetAsLastSibling();
            texts1[i].text = messages[i];
            RectTransform blockRect = blocks1[i].GetComponent<RectTransform>();
            if (i != 0)
            {
                blockRect.anchoredPosition = positions1[i * 2];
            }
            else
            {
                blockRect.anchoredPosition = positions1[i];
            }
            var blockact = blocks1[i].GetComponent<DragHandler>();
            if (blockact != null)
            {
                blockact.enabled = false;
            }
        }
        for (int i = 0; i < count; i++)
        {
            schemes1[i].gameObject.SetActive(true);
            schemes1[i].transform.SetAsLastSibling();
            schemes1[i].sprite = extra[i];
            RectTransform schemeRect = schemes1[i].GetComponent<RectTransform>();
            if ((i != 0))
            {
                schemeRect.anchoredPosition = positions1[i * 2 + 1];
            }
            else
            {
                schemeRect.anchoredPosition = positions1[i + 1];
            }
            var schemeact = schemes1[i].GetComponent<DragHandler>();
            if (schemeact != null)
            {
                schemeact.enabled = false;
            }
        }
    }
    private void Continue()
    {
        PlayerPrefs.SetInt("RealS", 0);
        PlayerPrefs.Save();
        Learn.DelScheme();
        SceneManager.LoadScene("Main");
    }
}
