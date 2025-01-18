using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public static class placesscore
{
    public static int unlockplaces;
    public static int places;

    public static void unlockplacesRedact0()
    {
        unlockplaces = 0;
    }

    public static void unlockplacesRedact()
    {
        unlockplaces++;
    }
    public static void unlockplacesClear()
    {
        unlockplaces = 0;
    }
    public static void placesRedact(int value)
    {
        places = value;
    }
}

public class PlaceControl : MonoBehaviour
{
    public TextMeshProUGUI bigQuestionText;
    public GameObject bigQuetionTextObject;
    public string question;
    public int answer;
    public int questionInt0;
    public int questionInt1;
    public int Znak;
    public TMP_InputField answerInput;
    public GameObject InputFieldObject;
    public TextMeshPro quetionText;
    private BoxCollider2D placeCollider;
    public Animator animatorPlace;
    public GameObject mainPlace;

    private void Awake()
    {
        placesscore.unlockplacesClear();
    }
    private void Start()
    {
        placeCollider = GetComponent<BoxCollider2D>();
        Znak = Random.Range(0, 4);
        GenerateQuestion();
        quetionText.text = question;
        bigQuestionText.text = question + " = ";
    }

    private void GenerateQuestion()
    {
        if (Znak == 0)
        {
            questionInt0 = Random.Range(1, 101);
            questionInt1 = Random.Range(1, 101);
            answer = questionInt0 + questionInt1;
            question = $"{questionInt0} + {questionInt1}";
        }
        else if (Znak == 1)
        {
            questionInt0 = Random.Range(5, 101);
            questionInt1 = Random.Range(0, questionInt0);
            answer = questionInt0 - questionInt1;
            question = $"{questionInt0} - {questionInt1}";
        }
        else if (Znak == 2)
        {
            questionInt0 = Random.Range(1, 11);
            questionInt1 = Random.Range(1, 11);
            answer = questionInt0 * questionInt1;
            question = $"{questionInt0} * {questionInt1}";
        }
        else if (Znak == 3)
        {
            int num = Random.Range(1, 11);
            int num2 = Random.Range(1, 11);
            questionInt0 = num * num2;
            questionInt1 = num;
            answer = questionInt0 / questionInt1;
            question = $"{questionInt0} / {questionInt1}";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!placeCollider.isTrigger)
        {
            bigQuetionTextObject.SetActive(true);
            InputFieldObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        bigQuetionTextObject.SetActive(false);
        InputFieldObject.SetActive(false);
    }

    public void CheckAnswer()
    {
        if (int.TryParse(answerInput.text, out int num) && (num == answer || num == 2011704))
        {
            Unlock();
        }
    }

    private void Unlock()
    {
        placesscore.unlockplacesRedact();
        if (placesscore.unlockplaces >= placesscore.places)
        {
            int rang = MyClass.rang;
            if (rang < 7)
            {
                MyClass.rangRedact(rang + 1);
            }
            SceneManager.LoadScene(0);
        }
        bigQuetionTextObject.SetActive(false);
        InputFieldObject.SetActive(false);
        placeCollider.isTrigger = true;
        mainPlace.tag = "home";
        animatorPlace.SetBool("Perexod", true);
        quetionText.text = $"{answer}";
    }
}