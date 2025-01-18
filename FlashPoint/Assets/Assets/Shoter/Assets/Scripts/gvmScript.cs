using UnityEngine;

public class gvmScript : MonoBehaviour
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
        targetPosition = new Vector3(917f, 428.24f, 0f);
        targetPosition1 = new Vector3(1143f, 428.24f, 0f);
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


    public void onEn()
    {
        isSliding = true;
        isSlidingIn = false;

    }


    public void onDis()
    {
        Invoke("TrueSlideIn", 3f);
    }
    private void TrueSlideIn()
    {
        isSlidingIn = true;
        isSliding = false;
    }
}