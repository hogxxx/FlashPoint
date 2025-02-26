using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CalendarControl : MonoBehaviour
{
    public GameObject[] BlockDayButton;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("UnlockData"))
        {
            PlayerPrefs.SetInt("UnlockData", int.Parse(DateTime.Now.ToString("yyyyMMdd")));
            Go.UpTime1();
            Go.UpScheme();
            BrainProject.UpTime();
        }
        if (!PlayerPrefs.HasKey("UnlockLevel"))
        {
            PlayerPrefs.SetInt("UnlockLevel", 1);
        }
        if (!PlayerPrefs.HasKey("AccessibleLevel"))
        {
            PlayerPrefs.SetInt("AccessibleLevel", 1);
        }
        if (PlayerPrefs.GetInt("AccessibleLevel") < PlayerPrefs.GetInt("UnlockLevel"))
        {
            if (int.Parse(DateTime.Now.ToString("yyyyMMdd")) > PlayerPrefs.GetInt("UnlockData"))
            {
                PlayerPrefs.SetInt("AccessibleLevel", PlayerPrefs.GetInt("UnlockLevel"));
                Go.UpTime1();
                Go.UpScheme(); 
                BrainProject.UpTime();
            }
        }
        for (int i = 0; i < BlockDayButton.Length; i++)
        {
            BlockDayButton[i].SetActive(true);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("AccessibleLevel"); i++)
        {
            BlockDayButton[i].SetActive(false);
        }

    }
}
