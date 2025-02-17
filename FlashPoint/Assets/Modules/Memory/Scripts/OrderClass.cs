using System.IO;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OrderClass : MonoBehaviour
{
    // Start is called before the first frame update
    public ToggleGroup group;
    public TextMeshProUGUI Choose;
    public Button ready;
    public static int classnum;
    private static List<string> order = new List<string>();
    private static List<string> distractingWords = new List<string>
    {
        "клітина",
        "орган",
        "тканина",
        "ген",
        "мембрана",
        "хромосома",
        "мутант",
        "ДНК",
        "РНК",
        "організм",
        "екосистема",
        "вода",
        "кров",
        "нерв",
        "м’яз",
        "іон",
        "вітамін",
        "гомеостаз",
        "реплікація",
        "мітохондрія",
        "ендоплазма",
        "метаболізм",
        "вид",
        "популяція",
        "селекція",
        "фотосинтез",
        "біосфера",
        "атом",
        "молекула",
        "реакція",
        "кислота",
        "лужність",
        "розчин",
        "каталізатор",
        "енергія",
        "електроліт",
        "валентність",
        "окиснення",
        "відновлення",
        "газ",
        "сіль",
        "кисень",
        "водень",
        "температура",
        "пластик",
        "радіус атома",
        "гідроліз",
        "алотропія",
        "хімічний зв'язок",
        "масова частка",
        "йон",
        "фтор",
        "ізотоп",
        "растворність",
        "сила",
        "енергія",
        "імпульс",
        "маса",
        "швидкість",
        "прискорення",
        "вага",
        "тиск",
        "об’єм",
        "температура",
        "тертя",
        "гравітація",
        "кінетика",
        "момент",
        "резонанс",
        "електрон",
        "магніт",
        "фотон",
        "струм",
        "індукція",
        "опір",
        "потенціал",
        "напруга",
        "амплітуда",
        "частота",
        "відстань",
        "хвиля",
        "інформація",
        "кодування",
        "процес",
        "пам'ять",
        "пристрій",
        "біт",
        "байт",
        "сервер",
        "компіляція",
        "диск",
        "команда",
        "підключення",
        "редактор",
        "дані",
        "кеш",
        "адаптер",
        "моніторинг",
        "протокол",
        "шифрування",
        "мережа",
        "архівування",
        "логіка",
        "алгоритм",
        "перемикач",
        "вебсайт",
        "пакет",
        "інтерфейс",
        "число",
        "дроби",
        "вектор",
        "координати",
        "периметр",
        "площа",
        "об’єм",
        "радіус",
        "кут",
        "рівняння",
        "функція",
        "графік",
        "диференціал",
        "логарифм",
        "матриця",
        "похідна",
        "інтеграл",
        "гіпотенуза",
        "парабола",
        "паралель",
        "асимптота",
        "симетрія",
        "пропорція",
        "дискримінант",
        "множення",
        "геометрія",
        "чисельник"
    };
    void Start()
    {
        foreach (Toggle point in group.GetComponentsInChildren<Toggle>())
        {
            point.onValueChanged.AddListener(delegate { Checker(point); });
        }
        ready.onClick.AddListener(Save);
    }
    private void Checker(Toggle point)
    {
        if (point.isOn)
        {
            TextMeshProUGUI classer = point.GetComponentInChildren<TextMeshProUGUI>(true);
            string classers = classer.text;
            int.TryParse(classers, out classnum);
        }
    }
    private void Save()
    {
        if (classnum != 0)
        {
            PlayerPrefs.SetInt("Class", classnum);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main");
        }
        else
        {
            StartCoroutine(Error());
        }
    }
    public static void LoadData(int num)
    {
        DistructWords.distructwords = distractingWords;
        order.Add("Інфо це втао овтів аівап пва"); /* !!!!!!!!!!!!!! */
        FileManager.SaveOrder(order);
    }
    private IEnumerator Error()
    {
        Choose.text = "Обери клас!";
        Choose.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Choose.gameObject.SetActive(false);
    }
}
public static class DistructWords
{
    public static List<string> distructwords { get; set; } = new List<string>();
}
public static class FileManager
{
    private static string filepath;
    private static void InitializeFilePath()
    {
        if (string.IsNullOrEmpty(filepath))
        {
            filepath = Application.persistentDataPath + "/order.json";
        }
    }
    public static void SaveOrder(List<string> orderlist)
    {
        InitializeFilePath();
        SerializableList orderlister = new SerializableList();
        foreach (var item in orderlist)
        {
            orderlister.Order.Add(item);
        }
        string json = JsonUtility.ToJson(orderlister, true);
        File.WriteAllText(filepath, json);
    }
    public static List<string> LoadTerms()
    {
        InitializeFilePath();
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            SerializableList filegot = JsonUtility.FromJson<SerializableList>(json);
            List<string> result = new List<string>();
            if (filegot.Order != null && filegot != null)
            {
                foreach (var serialize in filegot.Order)
                {
                    result.Add(serialize);
                }
            }
            return result;
        }
        else
        {
            return new List<string>();
        }
    }
}
[System.Serializable]
public class SerializableList
{
    public List<string> Order = new List<string>();
}
