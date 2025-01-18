using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text questionText;
    public Text feedbackText;
    public Text timer_text;
    public InputField answerInput;
    public MovePanel panel;
    public GameObject exit;
    public Button b_exit;
    public GameObject repear;
    public Button repear_b;
    public Text end;
    public Text coinText;

    public GameObject talkText;
    public Text talkText_t;

    public Dropdown levelDropdown;
    public Dropdown modeDropdown;
    public Button startButton;
    public Text dropdownHeaderText;
    public Text dropdownHeaderText1;
    public GameObject drop_panel;

    private int currentQuestion = 1;
    private int correctAnswer;
    private int correctAnswer2;
    private int correctAnswer0;
    private int znak;
    private int numberOfQuestions = 12;
    private int ans;
    private int all_ans;
    private int repearters;
    private int cod;
    private int timer;
    private int coins;

    private int selectedLevel;
    private string selectedMode;

    private void Start()
    {

        InitializeDropdown(levelDropdown, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100); 
        InitializeDropdown(modeDropdown, "Тренувальний", "Контрольний"); 
        startButton.onClick.AddListener(StartGame);
        Invoke("rel", 1f);
        panel.SlideNoIn();
        b_exit.onClick.AddListener(exit_f);
        repear_b.onClick.AddListener(repeart_fall);
        Time.fixedDeltaTime = 1f;
    }
    void InitializeDropdown(Dropdown dropdown, params object[] options)
    {
        
        dropdown.options.Clear();
        foreach (var option in options)
        {
            dropdown.options.Add(new Dropdown.OptionData(option.ToString()));
        }

        
        dropdown.onValueChanged.AddListener((value) => OnDropdownValueChanged(dropdown, value));

        
        dropdown.value = 0;
        OnDropdownValueChanged(dropdown, dropdown.value);
    }

    void OnDropdownValueChanged(Dropdown dropdown, int value)
    {
        
        if (dropdown == levelDropdown)
        {
            selectedLevel = value + 1;
            dropdownHeaderText.text = "Кількість запитань: " + selectedLevel;
        }
        else if (dropdown == modeDropdown)
        {
            selectedMode = dropdown.options[value].text;
            dropdownHeaderText1.text = "Режим гри: " + selectedMode;
        }
    }
    void StartGame()
    {
        talkText.SetActive(false);
        drop_panel.SetActive(false);
        Debug.Log("Selected Level: " + selectedLevel);
        Debug.Log(selectedMode);
        ShowNextQuestion();
        numberOfQuestions = selectedLevel;
        if (selectedMode == "Тренувальний")
        {
            talkText.SetActive(true);
        }

        timer = 0;
        timer_text.text = $"{timer} сек";
        coins = 0;
        coinText.text = $"{coins}";
        Invoke("ChestActive", 0.3f);
    }
    private void FixedUpdate()
    {
        timer += 1;
        timer_text.text = $"{timer} сек";
    }
    private void ShowNextQuestion()
    {
        

        if (currentQuestion > numberOfQuestions)
        {
            talkText.SetActive(false);
            cod = 100000;
            repearters += 100;
            if (ans > all_ans)
            {
                all_ans = ans;
            }
            feedbackText.text = "";
            Debug.Log(all_ans);
            
            end.text = $"Ви заробили {ans} монет за {timer} секунд. Бажаєте покращити результат?";
            repear.SetActive(true);
            exit.SetActive(true);
            panel.SlideIn();
            panel.SlideIn();
            ans = 0;

            return;
        }

        correctAnswer = Random.Range(10, 101);
        correctAnswer2 = Random.Range(10, 101);
        znak = Random.Range(0, 2);
        if(znak == 1)
        {
            correctAnswer0 = correctAnswer - correctAnswer2;
            questionText.text = $"{correctAnswer} - {correctAnswer2} = ?";
        }
        else
        {
            correctAnswer0 = correctAnswer + correctAnswer2;
            questionText.text = $"{correctAnswer} + {correctAnswer2} = ?";
        }
        

        Invoke("feedback", 1f);
    }

    public void CheckAnswer()
    {
        talkText_t.text = "";
        string playerAnswer = answerInput.text;
        int parsedAnswer;
        if (int.TryParse(playerAnswer, out parsedAnswer))
        {
            if (parsedAnswer == correctAnswer0)
            {
                StartCoroutine(ShowFeedback("Правильно!"));
                ans += 1;
                currentQuestion++;
                coins += 1;
                coinText.text = $"{coins}";
            }
            else if(parsedAnswer == 02011704)
            {
                StartCoroutine(ShowFeedback("Чит код активен!"));
                currentQuestion += 10;
                ans += 10;
            }
            else
            {
                StartCoroutine(ShowFeedback("Неправильно!"));
                currentQuestion++;
                talkText_t.text = $"Правильна відповідь: {correctAnswer0}";
            }
        }
        else
        {
            StartCoroutine(ShowFeedback("Введите корректное число!"));
        }
        panel.SlideOut();
        answerInput.text = "";
    }

    private IEnumerator ShowFeedback(string text)
    {
        feedbackText.text = text;
        yield return new WaitForSeconds(2f);
        ShowNextQuestion();
    }
    void feedback()
    {
        feedbackText.text = "";
    }
    void repeart_fall()
    {
        if (selectedMode == "Тренувальний")
        {
            talkText.SetActive(true);
        }
        currentQuestion = 1;
        end.text = "";
        exit.SetActive(false);
        repear.SetActive(false);
        panel.SlideNoIn();
        ShowNextQuestion();
        timer = 0;
    }
    void exit_f()
    {
        SceneManager.LoadScene(0);
    }
    void end_fall()
    {
        SceneManager.LoadScene(2);
    }
}
