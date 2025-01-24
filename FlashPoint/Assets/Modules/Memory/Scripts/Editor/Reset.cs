using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [MenuItem("Tools/Reseter")]
    public static void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Reseter");
    }
}
