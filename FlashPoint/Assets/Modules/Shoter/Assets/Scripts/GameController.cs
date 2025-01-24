using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject buttonExit;
    public Button buttonExit1;

    public GameObject[] onEnButtons;
    public GameObject[] onEnrepeartButtons;
    public Button[] answerButtons;
    public Button button1;
    public Button button2;
    public SlideOutB scriptA;
    public SlideOutB scriptB;
    public SlideOutB scriptC;
    public SlideOutB scriptD;
    public SlideOutB scriptE;

    public SlideLader Lader1;
    public SlideLader Lader1A;
    public SlideLader Lader1B;
    public SlideLader Lader2;
    public SlideLader Lader2A;
    public SlideLader Lader2B;
    public SlideLader Lader3;
    public SlideLader Lader3A;
    public SlideLader Lader3B;
    public SlideLader Lader4;
    public SlideLader Lader4A;
    public SlideLader Lader4B;
    public SlideLader Lader5;
    public SlideLader Lader5A;
    public SlideLader Lader5B;
    public SlideLader Lader6;
    public SlideLader Lader6A;
    public SlideLader Lader6B;
    public SlideLader Lader7;
    public SlideLader Lader7A;
    public SlideLader Lader7B;
    public SlideLader Lader8;
    public SlideLader Lader8A;
    public SlideLader Lader8B;
    public SlideLader Lader9;
    public SlideLader Lader9A;
    public SlideLader Lader9B;
    public SlideLader Lader10;
    public SlideLader Lader10A;
    public SlideLader Lader10B;
    public SlideLader Lader11;
    public SlideLader Lader11A;
    public SlideLader Lader11B;
    public SlideLader Lader12;
    public SlideLader Lader12A;
    public SlideLader Lader12B;

    public CameraSwing CamSw;

    public gvmScript gvmSc;

    public GameObject stair0;
    public GameObject stair1;
    public GameObject stair2;
    public GameObject stair3;
    public GameObject stair4;
    public GameObject stair5;
    public GameObject stair6;
    public GameObject stair7;
    public GameObject stair8;
    public GameObject stair9;
    public GameObject stair10;
    public GameObject stair11;

    public Text questionText;
    public Text resultText;
    public Text gvT;
    public Text gvmT;

    public GameObject gvTo;

    public GameObject staircasePrefab;
    public GameObject questionText1;
    public GameObject resultText1;
    public GameObject cam;
    public GameObject fon;
    public GameObject gvFon;
    public GameObject gvmFon;

    public List<Question> questions;

    public int Spawnpoint = 12;
    public int ans = 0;
    public int all_ans = 0;
    public int popitki = 0;
    public int cod = 100000;

    public int gv;
    public int gvm;

    private int currentLevel = 0;
    private int currentQuestionIndex = 0;
    public int iS = -1;

    private float camInt = 0f;

    private void OnEnable()
    {
        gvTo.SetActive(true);
        questionText1.SetActive(true);
        resultText1.SetActive(true);
        for (int e = 0; e < onEnButtons.Length; e++)
        {
            onEnButtons[e].SetActive(true);
        }
        gvFon.SetActive(true);
        gvmFon.SetActive(true);
    }

    void Start()
    {
        ShuffleQuestions();
        DisplayQuestion();
        button1.onClick.AddListener(OnButtonClick);
        button2.onClick.AddListener(OnButtonClick);
        buttonExit1.onClick.AddListener(OnExit);
        gv = 30;
        gvm = 0;
        string sGv = gv.ToString();
        gvT.text = sGv;

    }

    void ShuffleQuestions()
    {
        System.Random rng = new System.Random();
        int n = questions.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Question value = questions[k];
            questions[k] = questions[n];
            questions[n] = value;
        }
    }

    private void Update()
    {
        if (camInt <= 50)
        {
            Vector3 curPos = cam.transform.position;
            curPos.x += -0.0016f;
            curPos.y += 0.0075f;
            camInt += 1;

            cam.transform.position = curPos;
        }
    }

    void DisplayQuestion()
    {
        gvm = 0;
        questionText1.SetActive(true);
        for (int e = 0; e < onEnButtons.Length; e++)
        {
            onEnButtons[e].SetActive(true);
        }
        scriptA.OnEn();
        scriptB.OnEn();
        scriptC.OnEn();
        scriptD.OnEn();
        scriptE.OnEn();

        if (currentQuestionIndex < questions.Count)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            questionText.text = currentQuestion.questionText;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < currentQuestion.Answers.Length)
                {
                    answerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.Answers[i];
                    int index = i;
                    answerButtons[i].onClick.RemoveAllListeners();
                    answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false);
                }
            }

            resultText.text = "";
        }
        else
        {
            popitki += 100;
            if (ans > all_ans)
            {
                all_ans = ans;
            }
            ans = 0;
            
            foreach (var button in answerButtons)
            {
                button.gameObject.SetActive(false);
            }
            if (all_ans == 12)
            {
                Debug.Log("WIIIN!!!!!!");
                questionText.text = "¬≥таю, ви д≥стали м'€ч!";
                onEnrepeartButtons[1].SetActive(true);
                CamMove();
                CamSw.Win();
                gvTo.SetActive(false);
                gvFon.SetActive(false);
                gvmFon.SetActive(false);
            }
            else
            {
                questionText.text = "¬и майже д≥сталис€ до м'€ча, бажаЇте повторити?";
                for (int q = 0; q < onEnrepeartButtons.Length; q++)
                {
                    onEnrepeartButtons[q].SetActive(true);
                }
            }
            resultText.text = "";
            Debug.Log(popitki);
            Debug.Log(all_ans);
            Debug.Log(ans);
        }
    }

    void OnAnswerSelected(int selectedAnswerIndex)
    {
        if (currentQuestionIndex < questions.Count && iS < Spawnpoint)
        {
            scriptA.OnDis();
            scriptB.OnDis();
            scriptC.OnDis();
            scriptD.OnDis();
            scriptE.OnDis();
            Invoke("DelBut", 1f);
            Question currentQuestion = questions[currentQuestionIndex];
            if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
            {
                AddStaircase();
                resultText.text = "";
                iS += 1;
            }
            else
            {
                resultText.text = "";
            }

            currentQuestionIndex++;
            Invoke("DisplayQuestion", 3f);
        }
    }
    void DelBut()
    {
        
        questionText1.SetActive(false);
        for (int e = 0; e < onEnButtons.Length; e++)
        {
            onEnButtons[e].SetActive(false);
        }
    }
    void AddStaircase()
    {
        Debug.Log(iS);
        
        
        ans += 1;

        gv -= 2;
        gvm = -2;

        string sGvm = gvm.ToString();
        gvmT.text = sGvm;

        gvmSc.onEn();
        gvmSc.onDis();


        Invoke("CamMove", 3f);

        currentLevel++;

        string sGv = gv.ToString();
        gvT.text = sGv;

        if (iS == 0)
        {
            stair0.SetActive(true);
            Lader1.OnEn();
            Lader1A.OnEn();
            Lader1B.OnEn();
        }
        if (iS == 1)
        {
            stair1.SetActive(true);
            Lader2.OnEn();
            Lader2A.OnEn();
            Lader2B.OnEn();
        }
        if (iS == 2)
        {
            stair2.SetActive(true);
            Lader3.OnEn();
            Lader3A.OnEn();
            Lader3B.OnEn();
        }
        if (iS == 3)
        {
            stair3.SetActive(true);
            Lader4.OnEn();
            Lader4A.OnEn();
            Lader4B.OnEn();
        }
        if (iS == 4)
        {
            stair4.SetActive(true);
            Lader5.OnEn();
            Lader5A.OnEn();
            Lader5B.OnEn();
        }
        if (iS == 5)
        {
            stair5.SetActive(true);
            Lader6.OnEn();
            Lader6A.OnEn();
            Lader6B.OnEn();
        }
        if (iS == 6)
        {
            stair6.SetActive(true);
            Lader7.OnEn();
            Lader7A.OnEn();
            Lader7B.OnEn();
        }
        if (iS == 7)
        {
            stair7.SetActive(true);
            Lader8.OnEn();
            Lader8A.OnEn();
            Lader8B.OnEn();
        }
        if (iS == 8)
        {
            stair8.SetActive(true);
            Lader9.OnEn();
            Lader9A.OnEn();
            Lader9B.OnEn();
        }
        if (iS == 9)
        {
            stair9.SetActive(true);
            Lader10.OnEn();
            Lader10A.OnEn();
            Lader10B.OnEn();
        }
        if (iS == 10)
        {
            stair10.SetActive(true);
            Lader11.OnEn();
            Lader11A.OnEn();
            Lader11B.OnEn();
        }
        if (iS == 11)
        {
            stair11.SetActive(true);
            Lader12.OnEn();
            Lader12A.OnEn();
            Lader12B.OnEn();
        }





            
        
    }
    void CamMove()
    {
        camInt = 0f;
    }
    void OnButtonClick()
    {

        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == button1.gameObject)
        {
            pasiveSpawnedObjects();
            currentLevel = 0;
            currentQuestionIndex = 0;
            iS = 0;
            camInt = 0f;
            gv += 30;
            Vector3 curPos = cam.transform.position;
            curPos.x = 253.787f;
            curPos.y = 9.34f;

            cam.transform.position = curPos;
            questionText1.SetActive(false);
            for (int q = 0; q < onEnrepeartButtons.Length; q++)
            {
                onEnrepeartButtons[q].SetActive(false);
            }
            Debug.Log("error");
            
            ShuffleQuestions();
            DisplayQuestion();
            

        }   
        else if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == button2.gameObject)
        {
            ExitCod();

        }
    }
    void pasiveSpawnedObjects()
    {
        
        stair0.SetActive(false);
        stair1.SetActive(false);
        stair2.SetActive(false);
        stair3.SetActive(false);
        stair4.SetActive(false);
        stair5.SetActive(false);
        stair6.SetActive(false);
        stair7.SetActive(false);
        stair8.SetActive(false);
        stair9.SetActive(false);
        stair10.SetActive(false);
        stair11.SetActive(false);
        Lader1.OnDis();
        Lader1A.OnDis();
        Lader1B.OnDis();
        Lader2.OnDis();
        Lader2A.OnDis();
        Lader2B.OnDis();
        Lader3.OnDis();
        Lader3A.OnDis();
        Lader3B.OnDis();
        Lader4.OnDis();
        Lader4A.OnDis();
        Lader4B.OnDis();
        Lader5.OnDis();
        Lader5A.OnDis();
        Lader6B.OnDis();
        Lader6.OnDis();
        Lader6A.OnDis();
        Lader6B.OnDis();
        Lader7.OnDis();
        Lader7A.OnDis();
        Lader7B.OnDis();
        Lader8.OnDis();
        Lader8A.OnDis();
        Lader8B.OnDis();
        Lader9.OnDis();
        Lader9A.OnDis();
        Lader9B.OnDis();
        Lader10.OnDis();
        Lader10A.OnDis();
        Lader10B.OnDis();
        Lader11.OnDis();
        Lader11A.OnDis();
        Lader11B.OnDis();
        Lader12.OnDis();
        Lader12A.OnDis();
        Lader12B.OnDis();
    }
    void ExitCod()
    {
        gvFon.SetActive(false);
        gvmFon.SetActive(false);
        gvTo.SetActive(false);
        for (int p = 0; p < onEnrepeartButtons.Length; p++)
        {
            onEnrepeartButtons[p].SetActive(false);
        }
        cod += popitki;
        cod += all_ans;
        string strcod = cod.ToString();
        questionText.text = ("÷ей код над≥шли вчителю: " + strcod);
        buttonExit.SetActive(true);
    }
    void OnExit()
    {
        Debug.Log("Bye");
        SceneManager.LoadScene(0);
    }


}

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] Answers;
    public int correctAnswerIndex;
}
