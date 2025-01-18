using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rang : MonoBehaviour
{
    public GameObject[] rangs;
    public TMPro.TextMeshProUGUI pointsText;
    void Start()
    {
        rangs[MyClass.rang].SetActive(true);
    }

    private void Update()
    {
        pointsText.text = $"{MyClass.point}";
    }


}
