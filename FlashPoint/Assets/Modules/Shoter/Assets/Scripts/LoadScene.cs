using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    //public Button Level1;
    public Button Level2;
    public Button Level3;
    public MoveMenu panel;
    //public Button Level4;

    private void Start()
    {
        //Level1.onClick.AddListener(LoadSc1);
        Level2.onClick.AddListener(LoadSc2);
        Level3.onClick.AddListener(LoadSc3);
        //Level4.onClick.AddListener(LoadSc4);
    }
    /*public void LoadSc1()
    {
        SceneManager.LoadScene(1);
    }*/
    public void LoadSc2()
    {
        panel.OnEne();
        Invoke("load1", 2f);
    }
    public void LoadSc3()
    {
        panel.OnEne();
        Invoke("load2", 2f);
    }
    /*public void LoadSc4()
    {
        SceneManager.LoadScene(4);
    }*/
    void load1()
    {
        SceneManager.LoadScene(1);
    }
    void load2()
    {
        SceneManager.LoadScene(2);
    }
}
