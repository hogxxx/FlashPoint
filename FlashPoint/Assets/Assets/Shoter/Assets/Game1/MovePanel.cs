using UnityEngine;

public class MovePanel : MonoBehaviour
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
        targetPosition = new Vector3(0f, 0f, 0f);
        targetPosition1 = new Vector3(0f, 1100f, 0f);
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
            isSlidingIn = false;

            if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
            {
                isSliding = false;
            }
        }

    }


    public void SlideOut()
    {
        isSliding = true;
        Invoke("TrueSlideIn", 2f);
    }
    private void TrueSlideIn()
    {
        isSlidingIn = true;
    }
    public void SlideIn()
    {
        isSliding = true;
        isSlidingIn = false;
    }
    public void SlideNoIn()
    {
        isSlidingIn = true;
        isSliding = false;
    }
}