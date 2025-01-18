using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideOutB : MonoBehaviour
{
    public float slideSpeed = 5f;

    private Vector3 targetPosition;
    private Vector3 targetPosition1;
    private Vector3 initialPosition;

    private bool isSliding = false;
    private bool isSlidingIn = false;
    public float x;
    public float y;
    public float z;
    public float bx;
    public float by;
    public float bz;
    public float tably;

    private void Start()
    {
        initialPosition = transform.localPosition;
        targetPosition = new Vector3(x, y, z);
        targetPosition1 = new Vector3(bx, tably, bz);
    }

    private void Update()
    {
        if (isSlidingIn)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition1, slideSpeed * Time.deltaTime);
            isSliding = false;

            if (Vector3.Distance(transform.localPosition, targetPosition1) < 0.01f)
            {
                isSlidingIn = false;
            }
        }
        if (isSliding)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, slideSpeed * Time.deltaTime);


            if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
            {
                isSliding = false;
            }
        }

    }


    public void OnEn()
    {
        isSliding = true;
        isSlidingIn = false;
    }


    public void OnDis()
    {
        isSlidingIn = true;
        isSliding = false;
        Invoke("Dell", 2f);
    }
    void Dell()
    {
        transform.localPosition = new Vector3(bx, by, bz);
    }
}


