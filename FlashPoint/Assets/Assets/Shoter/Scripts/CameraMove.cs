using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;

 
    public float smoothSpeed = 0.125f;


    public Vector3 offset;


    public float fixedZ = -10f;  

    void LateUpdate()
    {
 
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, fixedZ);

  
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

   
        transform.position = smoothedPosition;
    }
}