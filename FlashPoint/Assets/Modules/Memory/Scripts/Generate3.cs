using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Generate3 : MonoBehaviour
{
    // Start is called before the first frame update
    private string Term;
    private List<string> Terms1 = new List<string>();
    private List<string> Terms2 = new List<string>();
    private List<string> RepetitionsEnd = new List<string>();
    private List<string> CorrectsKeys1 = new List<string>();
    private List<string> NotCorrectsKeys2 = new List<string>();
    private List<string> deleteskeys = new List<string>();
    private string sentence;
    private List<string> words;
    public GameObject area;
    public GameObject input;
    private Vector2[] positions1 =
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
    private List<Vector2> positions;
    public List<Image> blocks = new List<Image>(6);
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[6];
    private int counts;
    private int counts1;
    private int counts2;
    private List<GameObject> objects = new List<GameObject>();
    private List<GameObject> objectsOrder;
    private List<GameObject> objectsInput = new List<GameObject>();
    private List<string> ordertexts;
    private List<string> worders;
    private bool isCorrect = true;
    public GameObject panel;
    public TextMeshProUGUI mesage;
    public TextMeshProUGUI correctterm;
    public TextMeshProUGUI correct;
    public Button backer;
    private string agains4_4;
    private string agains4_4_keys;
    private string agains4_1;
    private string agains4_1_keys;
    public Button check;
    public TextMeshProUGUI error;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        agains4_4 = PlayerPrefs.GetString("4Again4");
        agains4_4_keys = PlayerPrefs.GetString("NotCorrectsKeys4");
        agains4_1 = PlayerPrefs.GetString("111Again");
        agains4_1_keys = PlayerPrefs.GetString("CorrectsKeys111");
        deleteskeys = new List<string>(PlayerPrefs.GetString("AllKeysCheck2").Split(";"));
        CorrectsKeys1 = new List<string>(agains4_1_keys.Split(";"));
        NotCorrectsKeys2 = new List<string>(agains4_4_keys.Split(";"));
        Terms1 = new List<string>(agains4_1.Split(";"));
        Terms2 = new List<string>(agains4_4.Split(";"));
        RepetitionsEnd = new List<string>(PlayerPrefs.GetString("Terms").Split(";"));
        Terms1 = DelCopy.RemoveDuplicates(Terms1);
        Terms2 = DelCopy.RemoveDuplicates(Terms2);
        CorrectsKeys1 = DelCopy.RemoveDuplicates(CorrectsKeys1);
        NotCorrectsKeys2 = DelCopy.RemoveDuplicates(NotCorrectsKeys2);
        if (!string.IsNullOrEmpty(agains4_4))
        {
            sentence = Terms2[0];
            Term = Terms2[0];
        }
        else if (!string.IsNullOrEmpty(agains4_1))
        {
            sentence = Terms1[0];
            Term = Terms1[0];
        }
        words = new List<string>(sentence.Split(" "));
        worders = new List<string>(words);
        counts = words.Count;
        positions = new List<Vector2>(positions1.Take(counts));
        counts1 = counts - 3;
        counts2 = counts - counts1;
        check.onClick.AddListener(Confirm);
        Generated();
    }
    private void Generated()
    {
        int size1 = positions.Count;
        for (int i = 0; i < counts1; i++)
        {
            GameObject areas1 = Instantiate(area, GameObject.Find("Container").transform);
            RectTransform rectTransform = areas1.GetComponent<RectTransform>();
            int rand = Random.Range(0, size1);
            rectTransform.anchoredPosition = positions[rand];
            positions.RemoveAt(rand);
            objects.Add(areas1);
            texts[i].text = words[rand];
            words.RemoveAt(rand);
            blocks[i].gameObject.SetActive(true);
            blocks[i].transform.SetAsLastSibling();
            RectTransform blockRect = blocks[i].GetComponent<RectTransform>();
            blockRect.anchoredPosition = rectTransform.anchoredPosition;
            var blockAct = blocks[i].GetComponent<DragHandler>();
            if (blockAct != null)
            {
                blockAct.enabled = false;
            }
            size1--;
        }
        area.gameObject.SetActive(false);
        int size2 = positions.Count;
        for (int i = 0; i < counts2; i++)
        {
            GameObject input1 = Instantiate(input, GameObject.Find("Container").transform);
            RectTransform rectTransform = input1.GetComponent<RectTransform>();
            int rand = Random.Range(0, size2);
            rectTransform.anchoredPosition = positions[rand];
            positions.RemoveAt(rand);
            objects.Add(input1);
            objectsInput.Add(input1);
            size2--;
        }
        input.gameObject.SetActive(false);
        objectsOrder = new List<GameObject>(new GameObject[objects.Count]);
        for (int i = 0; i < objects.Count; i++)
        {
            RectTransform objectPos = objects[i].GetComponent<RectTransform>();
            for (int j = 0; j < positions1.Length; j++)
            {
                if (positions1[j] == objectPos.anchoredPosition)
                {
                    objectsOrder[j] = objects[i];
                }
            }
        }
    }
    private void Confirm()
    {
        bool isFull = true;
        foreach (var thing in objectsInput)
        {
            TMP_InputField inputer = thing.GetComponent<TMP_InputField>();
            if (inputer == null || string.IsNullOrEmpty(inputer.text))
            {
                isFull = false;
            }
        }
        if (isFull)
        {
            Check();
        }
        else
        {
            StartCoroutine(Error());
        }
    }
    private IEnumerator Error()
    {
        error.text = "Заповни всі пропуски!";
        error.color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
        yield return new WaitForSeconds(1.5f);
        error.text = "Заповни пропуски!";
        error.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    }
    public void Check()
    {
        ordertexts = new List<string>();
        List<Image> blocksCopy = new List<Image>(blocks);
        foreach (var thing in objectsOrder)
        {
            if (thing.GetComponent<TMP_InputField>())
            {
                TMP_InputField inputer = thing.GetComponent<TMP_InputField>();
                string inputtext = inputer.text;
                ordertexts.Add(inputtext);
            }
            else if (thing.GetComponent<DropHandler>())
            {
                RectTransform droper = thing.GetComponent<RectTransform>();
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
        }
        if (ordertexts.Count == objectsOrder.Count)
        {
            isCorrect = true;

            for (int i = 0; i < objectsOrder.Count; i++)
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
        SaveString();
        PlayerPrefs.SetInt("Repeat4", 0);
        PlayerPrefs.SetInt("Note4", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main");
    }
    private void Add()
    {
        SaveString();
        PlayerPrefs.SetInt("Repeat4", 0);
        PlayerPrefs.SetInt("Note4", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main");
    }
    private void SaveString()
    {
        if (!string.IsNullOrEmpty(agains4_4))
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
            PlayerPrefs.SetString("AllKeysCheck2", termdel2);
            Terms2.RemoveAt(0);
            NotCorrectsKeys2.RemoveAt(0);
            string termstring2 = string.Join(";", Terms2);
            string termkey2 = string.Join(";", NotCorrectsKeys2);
            PlayerPrefs.SetString("NotCorrectsKeys4", termkey2);
            PlayerPrefs.SetString("4Again4", termstring2);
        }
        else
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
            PlayerPrefs.SetString("AllKeysCheck2", termdel1);
            Terms1.RemoveAt(0);
            CorrectsKeys1.RemoveAt(0);
            string termstring1 = string.Join(";", Terms1);
            string termkey1 = string.Join(";", CorrectsKeys1);
            PlayerPrefs.SetString("CorrectsKeys111", termkey1);
            PlayerPrefs.SetString("111Again", termstring1);
        }
        PlayerPrefs.Save();
    }
}
