using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.VersionControl;
using Unity.VisualScripting;
public class Training : MonoBehaviour
{
    // Start is called before the first frame update
    public Image MainPhoto;
    public List<Image> blocks = new List<Image>(5);
    private Vector2[] positions =
    {
        new Vector2(-8.468933f, 1.769623f),
        new Vector2(8.549622f, 1.769623f),
        new Vector2(8.549622f, -1.878525f),
        new Vector2(-8.468933f, -1.878525f),
        new Vector2(-4.302216f, -1.878525f),
    };
    public List<Sprite> sprites = new List<Sprite>();
    public List<GameObject> dropareas = new List<GameObject>(3);
    public GameObject panel;
    public TextMeshProUGUI message;
    public TextMeshProUGUI correctOrder;
    public Button menu;
    public Image MainPhoto2;
    public Image ImageT1;
    public Image ImageT2;
    public Image ImageT3;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Generated();
    }
    private void Generated()
    {
        int count = CountDay.LoadInter();
        List<Vector2> spawnPos = new List<Vector2>(positions);
        if (count == 6)
        {
            List<Sprite> sprites1 = sprites.GetRange(0, count);
            MainPhoto.sprite = sprites1[0];
            MainPhoto2.sprite = sprites1[0];
            ImageT1.sprite = sprites1[1];
            ImageT2.sprite = sprites1[2];
            ImageT3.sprite = sprites1[3];
            for (int i = 0; i < 5; i++)
            {
                blocks[i].sprite = sprites1[i + 1];
                int random = Random.Range(0, spawnPos.Count);
                RectTransform pos = blocks[i].GetComponent<RectTransform>();
                pos.anchoredPosition = spawnPos[random];
                spawnPos.RemoveAt(random);
            }
        }
        else
        {
            List<Sprite> sprites2 = sprites.GetRange(count, count + 6);
            MainPhoto.sprite = sprites2[0];
            MainPhoto2.sprite = sprites2[0];
            ImageT1.sprite = sprites2[1];
            ImageT2.sprite = sprites2[2];
            ImageT3.sprite = sprites2[3];
            for (int i = 0; i < 5; i++)
            {
                blocks[i].sprite = sprites2[i + 1];
                int random = Random.Range(0, spawnPos.Count);
                RectTransform pos = blocks[i].GetComponent<RectTransform>();
                pos.anchoredPosition = spawnPos[random];
                spawnPos.RemoveAt(random);
            }
        }
    }
    public void Check()
    {
        List<Image> blocksCopy = new List<Image>(blocks);
        int num = 0;
        bool correct = true;
        foreach(var image1 in blocksCopy)
        {
            RectTransform pos1 = image1.GetComponent<RectTransform>();
            foreach(var drop in dropareas)
            {
                RectTransform pos2 = drop.GetComponent<RectTransform>();
                if (RectOverLaps(pos1, pos2))
                {
                    num++;
                    if (!image1.CompareTag("TruePhoto"))
                    {
                        correct = false;
                    }
                }
            }
        }
        if (correct && num == 3)
        {
            Correct();
        }
        else if (num == 3)
        {
            NotCorrect();
        }
    }
    private bool RectOverLaps(RectTransform blocker, RectTransform droper)
    {
        Rect rect1 = new Rect
        (
            blocker.position.x - blocker.rect.width * blocker.lossyScale.x / 2,
            blocker.position.y - blocker.rect.height * blocker.lossyScale.y / 2,
            blocker.rect.width * blocker.lossyScale.x,
            blocker.rect.height * blocker.lossyScale.y
        );
        Rect rect2 = new Rect
        (
            droper.position.x - droper.rect.width * droper.lossyScale.x / 2,
            droper.position.y - droper.rect.height * droper.lossyScale.y / 2,
            droper.rect.width * droper.localScale.x,
            droper.rect.height * droper.lossyScale.y
        );
        return rect1.Overlaps(rect2);
    }
    private void Correct()
    {
        panel.gameObject.SetActive(true);
        message.text = "Правильно!";
        message.color = new Color(53f / 255f, 255f / 255f, 0f / 255f);
        menu.onClick.RemoveAllListeners();
        menu.onClick.AddListener(Back);
    }
    private void NotCorrect()
    {
        panel.gameObject.SetActive(true);
        message.text = "Не правильно!";
        message.color = new Color(255f / 255f, 59f / 255f, 0f / 255f);
        correctOrder.gameObject.SetActive(true);
        MainPhoto2.gameObject.SetActive(true);
        ImageT1.gameObject.SetActive(true);
        ImageT2.gameObject.SetActive(true);
        ImageT3.gameObject.SetActive(true);
        menu.onClick.RemoveAllListeners();
        menu.onClick.AddListener(Back);
    }
    private void Back()
    {
        SceneManager.LoadScene("Properties");
        PlayerPrefs.SetString("Day1", System.DateTime.Now.ToString("o"));
        PlayerPrefs.Save();
    }
}
