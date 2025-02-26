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
    "����������� ����� �� ��� ���������� �������� � ���������",
    "������� �� ������� �������� �� ������� ������ ������",
    "���� ������ �� ������� ������ �� ��������� �� ���",
    "��� �� ������� �������� �� ���������� ������ � ���������",
    "������� ���� �� ���� �� ����������� ����������� �������",
    "����� ��� �� ������������ �� �������� � �������",
    "�������������� �������� �� ����� ���������� ������ � ���������",
    "�������� �� ����� ������ ��������� �������� ��������",
    "�������� ��� �� ��������� ��� ������� � �������",
    "����� �� �������������� ����� ��� ������� ���",
    "���������� ����� �� ������ ��������� ���� ������������",
    "���������� ����� �� ���� �������� ���� ���������",
    "�������� �� ����������� ����� �� ���������� �������",
    "������ ���� �� ������� ���� �� ���������������� � ����������",
    "���������� ����� �� ������ ������� �� �������� ��������",
    "������������� �� ������ ����������� ������� ���� �����",
    "�����-������������� �� ���� ���� ���� �� ��������� ����",
    "������� ������ �� ������ ������ ������ ���� � �����",
    "��������� ��� �� ���� ��������� ��� � �������",
    "�������� �� ������� �������� �� ������� ��� ���",
    "���� �� ������� �� ����� ��� ���",
    "����������� �� ���� �������� ���� � �����",
    "���� �� ������� �������� �� ������� ������� ��������",
    "��������� �� ���� ���������� �� ����� � ������",
    "���� �� ���� ��� 䳺 �� ������� �����",
    "������ �� �������� ��� ���������� ������",
    "г������� ���� �� ����� ������ ��� ���� �����",
    "����� �� ������� ��� ��������� ������������ �����",
    "������ �� ���� �������� � ������� ����������� � ������",
    "����� ������ �� ���� ��������� ����㳿 �� ������� �������������"
    };
    private static List<string> distractingWords = new List<string>
    {
        "������",
        "�����",
        "�������",
        "���",
        "��������",
        "���������",
        "������",
        "���",
        "���",
        "�������",
        "����������",
        "����",
        "����",
        "����",
        "���",
        "���",
        "�����",
        "���������",
        "���������",
        "���������",
        "����������",
        "���������",
        "���",
        "���������",
        "��������",
        "����������",
        "�������",
        "����",
        "��������",
        "�������",
        "�������",
        "�������",
        "������",
        "����������",
        "������",
        "���������",
        "����������",
        "���������",
        "����������",
        "���",
        "���",
        "������",
        "������",
        "�����������",
        "�������",
        "����� �����",
        "������",
        "��������",
        "������� ��'����",
        "������ ������",
        "���",
        "����",
        "������",
        "�����������",
        "����",
        "������",
        "�������",
        "����",
        "��������",
        "�����������",
        "����",
        "����",
        "�ᒺ�",
        "�����������",
        "�����",
        "���������",
        "�������",
        "������",
        "��������",
        "��������",
        "�����",
        "�����",
        "�����",
        "��������",
        "���",
        "���������",
        "�������",
        "��������",
        "�������",
        "�������",
        "�����",
        "����������",
        "���������",
        "������",
        "���'���",
        "�������",
        "��",
        "����",
        "������",
        "���������",
        "����",
        "�������",
        "����������",
        "��������",
        "���",
        "���",
        "�������",
        "���������",
        "��������",
        "����������",
        "������",
        "�����������",
        "�����",
        "��������",
        "���������",
        "�������",
        "�����",
        "���������",
        "�����",
        "�����",
        "������",
        "����������",
        "��������",
        "�����",
        "�ᒺ�",
        "�����",
        "���",
        "�������",
        "�������",
        "������",
        "�����������",
        "��������",
        "�������",
        "�������",
        "��������",
        "���������",
        "��������",
        "��������",
        "���������",
        "�������",
        "���������",
        "�����������",
        "��������",
        "��������",
        "���������"
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
        if (num != 0 && Learn.termsDay.Contains("�������: " + Physics[num - 1]))
        {
            Learn.termsDay.Remove("�������: " + Physics[num - 1]);
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
        Choose.text = "����� ����!";
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
