using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoWin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject view1;
    public GameObject view2;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        int num = PlayerPrefs.GetInt("RealS");
        if (num == 1)
        {
            view2.gameObject.SetActive(true);
        }
        else
        {
            view1.gameObject.SetActive(true);
        }
    }
}
