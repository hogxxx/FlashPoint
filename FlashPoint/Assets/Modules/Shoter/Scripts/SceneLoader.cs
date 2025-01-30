using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class MyClass
{
    public static int rang;
    public static int point;
    public static int lifes;

    public static void rangRedact(int value)
    {
        rang = value;
        PlayerPrefs.SetInt("rang", rang);
        PlayerPrefs.Save();
    }
    public static void pointRedact(int value)
    {
        point = value;
        PlayerPrefs.SetInt("point", point);
        PlayerPrefs.Save();
    }
    public static void lifesRedact(int value)
    {
        lifes = value;
        PlayerPrefs.SetInt("lifes", lifes);
        PlayerPrefs.Save();
    }
}


public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        MyClass.rangRedact(PlayerPrefs.GetInt("rang"));
        MyClass.pointRedact(PlayerPrefs.GetInt("point"));
        if (PlayerPrefs.GetInt("lifes") > 2)
        {
            MyClass.lifesRedact(PlayerPrefs.GetInt("lifes"));
        }
        else
        {
            MyClass.lifesRedact(2);
        }
        
    }


    private int rang;
    private int point;
    private int lifes;

    public TMPro.TextMeshProUGUI textlife;


    public Button play;
    public Button update;
    public Button competishion;
    public Button traning;
    public Button start;
    public Button exit;

    public GameObject levelsMenu;
    void Start()
    {
        play.onClick.AddListener(playv);
        update.onClick.AddListener(updatev);
        competishion.onClick.AddListener(competishionv);
        traning.onClick.AddListener(traningv);
        start.onClick.AddListener(startv);
        exit.onClick.AddListener(exitv);
        rang = (int)MyClass.rang;
        Screen.orientation = ScreenOrientation.LandscapeLeft;

    }
    private void Update()
    {
        lifes = (int)MyClass.lifes;
        point = (int)MyClass.point;
        textlife.text = $"{lifes + 1}";
    }
    void startv()
    {
        levelsMenu.SetActive(true);
    }
    void exitv()
    {
        levelsMenu.SetActive(false);
    }
    void traningv()
    {
        SceneManager.LoadScene(9);
    }
    void competishionv()
    {
        
    }


    void playv()
    {
        SceneManager.LoadScene(rang + 5);
    }
    void updatev()
    {
        if(point >= 20)
        {
            if(lifes < 6)
            {
                MyClass.lifesRedact(lifes + 1);
                MyClass.pointRedact(point - 20);
            }
            
        }
        
    }
}
