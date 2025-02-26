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
    public static List<string> Physics = new List<string>()
    {
    "Електричний струм це рух заряджених частинок у провіднику",
    "Напруга це фізична величина що визначає роботу струму",
    "Сила струму це кількість заряду що проходить за час",
    "Опір це фізична величина що перешкоджає струму у провіднику",
    "Магнітне поле це поле що створюється електричним струмом",
    "Закон Ома це співвідношення між напругою і струмом",
    "Електромагнітна індукція це явище виникнення струму в провіднику",
    "Резонанс це явище різкого збільшення амплітуди коливань",
    "Тепловий рух це хаотичний рух молекул у речовині",
    "Світло це електромагнітна хвиля яку сприймає око",
    "Поглинання світла це процес зменшення його інтенсивності",
    "Заломлення світла це зміна напрямку його поширення",
    "Дисперсія це розкладання світла на спектральні кольори",
    "Звукові хвилі це механічні хвилі які розповсюджуються в середовищі",
    "Розсіювання світла це процес відбиття від частинок речовини",
    "Радіоактивність це процес спонтанного розпаду ядер атомів",
    "Альфа-випромінювання це потік ядер гелію які випромінює ядро",
    "Ядерний синтез це процес злиття легких ядер у важчі",
    "Механічний рух це зміна положення тіла у просторі",
    "Швидкість це фізична величина що визначає рух тіла",
    "Сила це взаємодія що змінює рух тіла",
    "Прискорення це зміна швидкості руху з часом",
    "Маса це фізична величина що визначає кількість речовини",
    "Гравітація це сила притягання між тілами у Всесвіті",
    "Тиск це сила яка діє на одиницю площі",
    "Енергія це здатність тіла виконувати роботу",
    "Рівнодійна сила це заміна кількох сил однією силою",
    "Лазер це пристрій для генерації когерентного світла",
    "Плазма це стан речовини з вільними електронами і йонами",
    "Закон Планка це опис залежності енергії від частоти випромінювання"
    };
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
        if (order.Count != 0)
        {
            order.Clear();
        }
        if (num != 0 && Learn.termsDay.Contains("Повтори: " + Physics[num - 1]))
        {
            Learn.termsDay.Remove("Повтори: " + Physics[num - 1]);
        }
        order.Add(Physics[num]);
        FileManager.SaveOrder(order);
    }
    public static void UpdateScheme()
    {
        if (!PlayerPrefs.HasKey("NumScheme"))
        {
            PlayerPrefs.SetInt("NumScheme", -1);
            PlayerPrefs.Save();
        }
        int num = PlayerPrefs.GetInt("NumScheme");
        if (num < 1)
        {
            num++;
            PlayerPrefs.SetInt("NumScheme", num);
            PlayerPrefs.Save();
        }
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
