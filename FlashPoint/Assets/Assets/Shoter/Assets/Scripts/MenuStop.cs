using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuStop : MonoBehaviour
{
    public Button buttonOff;
    public Button buttonOn;
    public Button buttonExit;
    public float slideSpeedB = 5f;

    private Vector3 targetPosition;
    private Vector3 targetPosition1;
    private Vector3 initialPosition;

    private bool isSliding = false;
    private bool isSlidingIn = false;
    private void Start()
    {
        buttonOff.onClick.AddListener(OffButtonClick1);
        buttonOn.onClick.AddListener(OnButtonClick1);
        buttonExit.onClick.AddListener(ExitButtonClick1);
        initialPosition = transform.localPosition;
        targetPosition = new Vector3(0f, 0f, 0f);
        targetPosition1 = new Vector3(-2357f, 0f, 0f);
    }
    void OnButtonClick1()
    {
        isSliding = true;
        isSlidingIn = false;
    }
    void OffButtonClick1()
    {
        isSlidingIn = true;
        isSliding = false;
    }
    void ExitButtonClick1()
    {
        Debug.Log("Bye");
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (isSlidingIn)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition1, slideSpeedB * Time.deltaTime);
        }
        if (isSliding)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, slideSpeedB * Time.deltaTime);
        }
    }
}
