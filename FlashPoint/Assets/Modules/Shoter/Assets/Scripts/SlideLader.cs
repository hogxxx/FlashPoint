using UnityEngine;

public class SlideLader : MonoBehaviour
{
    public float slideSpeed = 5f;

    private Vector3 targetPosition;

    private bool isSliding = false;
    public float x;
    public float y;
    public float z;
    public float bx;
    public float by;
    public float bz;

    private void Start()
    {
        
        targetPosition = new Vector3(x, y, z);
    }

    private void Update()
    {
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
    }


    public void OnDis()
    {
        transform.localPosition = new Vector3(bx, by, bz);
        isSliding = false;
        
    }
}
