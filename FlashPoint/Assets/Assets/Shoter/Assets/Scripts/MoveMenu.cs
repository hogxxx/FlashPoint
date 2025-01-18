using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    public float slideSpeed = 5f;

    private Vector3 targetPosition;
    private Vector3 initialPosition;

    private bool isSliding = false;
    public float x;
    public float y;
    public float z;
    private void Start()
    {
        initialPosition = transform.localPosition;
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

    public void OnEne()
    {
        isSliding = true;
    }
}
