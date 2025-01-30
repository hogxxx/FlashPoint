using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowsControl : MonoBehaviour
{
    public GameObject Register;
    public GameObject AwakePlash;
    public GameObject MainMenu;
    public GameObject ChosePrioritet;
    public GameObject MissionMenu;
    public GameObject ProfileMenu;
    public GameObject[] Missions;

    public Button RegisterAplyButton;
    public Button AwakeAplyButton;
    public Button[] DayButtons;
    public Button[] ChosePrioritetButtons;
    public Button MissionAplyButton;
    public Button ProfileEnterButton;
    public Button ProfileExitButton;

    private int Day;
    private int Prioritet;

    private void Start()
    {
        Register.SetActive(false);
        AwakePlash.SetActive(true);
        MainMenu.SetActive(false);
        ChosePrioritet.SetActive(false);
        MissionMenu.SetActive(false);
        ProfileMenu.SetActive(false);
        AwakeAplyButton.onClick.AddListener(AwakeAply);
        RegisterAplyButton.onClick.AddListener(RegisterAply);
        for (int i = 0; i < DayButtons.Length; i++)
        {
            int buttonIndex = i;
            DayButtons[i].onClick.AddListener(() => DayActive(buttonIndex));
        }
        for (int i = 0; i < ChosePrioritetButtons.Length; i++)
        {
            int buttonIndex = i;
            ChosePrioritetButtons[i].onClick.AddListener(() => PrioritetActive(buttonIndex));
        }
        MissionAplyButton.onClick.AddListener(MissionAply);
        ProfileEnterButton.onClick.AddListener(ProfileEnter);
        ProfileExitButton.onClick.AddListener(ProfileExit);
    }

    void AwakeAply()
    {
        AwakePlash.SetActive(false);
        Register.SetActive(true);
    }
    void RegisterAply()
    {
        Register.SetActive(false);
        MainMenu.SetActive(true);
    }
    void DayActive(int Days)
    {
        Day = Days;
        MainMenu.SetActive(false);
        ChosePrioritet.SetActive(true);
    }
    void PrioritetActive(int Prioritets)
    {
        Prioritet = Prioritets;
        ChosePrioritet.SetActive(false);
        MissionMenu.SetActive(true);
        Missions[Prioritet].SetActive(true);

    }
    void MissionAply()
    {
        SceneManager.LoadScene(Prioritet);
    }
    void ProfileEnter()
    {
        MainMenu.SetActive(false);
        ProfileMenu.SetActive(true);
    }
    void ProfileExit()
    {
        MainMenu.SetActive(true);
        ProfileMenu.SetActive(false);
    }

}
