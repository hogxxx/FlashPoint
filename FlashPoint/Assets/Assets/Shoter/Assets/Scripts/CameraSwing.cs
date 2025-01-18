using UnityEngine;

public class CameraSwing : MonoBehaviour
{
    public float rotationSpeed = 2f; 
    public GameObject currentTarget;
    public Vector3 rotationDegrees = new Vector3(0f, 45f, 0f);
    private Vector3 initialSwayRotation;
    private float Ri = -250f;
    private bool win = false;

    void Start()
    {
        currentTarget = GameObject.FindGameObjectWithTag("Target1"); 
        initialSwayRotation = transform.localEulerAngles;
        Ri = -250;
        win = false;
    }
    void Update()
    {
        if ((Vector3.Distance(transform.position, currentTarget.transform.position) < 0.1f) && (currentTarget.tag == "Target1") && (Ri <= 160))
        {
            initialSwayRotation = new Vector3(Ri / 10, -90f, 0f); 
            Ri += 1;
        }
        if (win && (Ri >= -250))
        {
            initialSwayRotation = new Vector3(Ri / 10, -90f, 0f);
            Ri -= 1;
        }
        float horizontalSway = Mathf.Sin(Time.time * 1f) * 1f;
        float verticalSway = Mathf.Sin(Time.time * 1f * 0.5f) * 0.7f;
        transform.localEulerAngles = initialSwayRotation + new Vector3(verticalSway, horizontalSway, 0f);    
    }
    public void Win()
    {
        win = true;
    }
}
