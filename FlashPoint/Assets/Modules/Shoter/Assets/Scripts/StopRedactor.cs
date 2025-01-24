using UnityEngine.UI;
using UnityEngine;

public class StopRedactor : MonoBehaviour
{
    public GameObject pause_off;
    public GameObject pause_on;
    public Button pause;
    public Button replay;
    private void Start()
    {
        pause.onClick.AddListener(on);
        replay.onClick.AddListener(off);
    }
    private void on()
    {
        pause_off.SetActive(false);
        pause_on.SetActive(true);
    }
    void off()
    {
        pause_off.SetActive(true);
        pause_on.SetActive(false);
    }
}
