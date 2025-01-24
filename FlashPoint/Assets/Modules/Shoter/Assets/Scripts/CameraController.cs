using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 1f; 
    private GameObject currentTarget; 
    private GameObject nextTarget; 
    public GameObject GameController1;
    
    public SlideOutUI scriptBReference;
    public GameObject textInf;
    public GameObject lightObj;
    public GameObject imInf;
    private bool study = true;
    public float rSpeed = 1f;

    private void Start()
    {
        currentTarget = GameObject.FindGameObjectWithTag("Target1"); 
        nextTarget = GameObject.FindGameObjectWithTag("Target2"); 
        Invoke("LightOn", 0.5f);
        Invoke("LightOff", 1f);
        Invoke("LightOn", 1.5f);
        Invoke("LightOff", 2f);
        Invoke("LightOn", 2.5f);
        Invoke("LightOff", 3f);
        Invoke("LightOn", 3.5f);
        Invoke("LightOff", 4f);
        Invoke("LightOn", 4.5f);
        Invoke("LightOff", 5f);
    }

    private void Update()
    {
        if (study)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, moveSpeed * Time.deltaTime);
        }
        

        
        if ((Vector3.Distance(transform.position, currentTarget.transform.position) < 0.1f) && (currentTarget.tag == "Target1"))
        {
            textInf.SetActive(true);
            imInf.SetActive(true);
            scriptBReference.SlideOut();
            scriptBReference.SlideIn();
            Invoke("ChangeTarget", 25f);

        }
        else if ((Vector3.Distance(transform.position, currentTarget.transform.position) < 0.1f) && (currentTarget.tag == "Target2"))
        {
            GameController1.SetActive(true);
            study = false;
        }
    }
    

    private void ChangeTarget()
    {


        textInf.SetActive(false);
        imInf.SetActive(false);
        currentTarget = nextTarget;




    }
    private void LightOn()
    {
        lightObj.SetActive(true);
    }
    private void LightOff()
    {
        lightObj.SetActive(false);
    }

}