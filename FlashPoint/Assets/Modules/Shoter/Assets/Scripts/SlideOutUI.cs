using UnityEngine;

public class SlideOutUI : MonoBehaviour
{
    public float slideSpeedB = 5f;

    private Vector3 targetPosition;
    private Vector3 targetPosition1;
    private Vector3 initialPosition;

    private bool isSliding = false;
    private bool isSlidingIn = false;
    private void Start()
    {
        initialPosition = transform.localPosition;
        targetPosition = new Vector3(-50f, -25f, 0f);
        targetPosition1 = new Vector3(2500f, 1500f, 0f);
    }

    private void Update()
    {
        if (isSlidingIn)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition1, slideSpeedB * Time.deltaTime);
            isSliding = false;

            if (Vector3.Distance(transform.localPosition, targetPosition1) < 0.01f)
            {
                isSlidingIn = false;
            }
        }
        if (isSliding)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, slideSpeedB * Time.deltaTime);


            if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
            {
                isSliding = false;
            }
        }

    }


    public void SlideOut()
    {
        isSliding = true;
    }


    public void SlideIn()
    {
        Invoke("TrueSlideIn", 20f);
    }
    private void TrueSlideIn()
    {
        isSlidingIn = true;
    }
}