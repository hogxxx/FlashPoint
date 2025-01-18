using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button StarT;
    public MoveMenu stertB;
    //public MoveMenu Level1;
    public MoveMenu Level2;
    public MoveMenu Level3;
    //public MoveMenu Level4;

    private void Start()
    {
        StarT.onClick.AddListener(onE);
    }
    private void onE()
    {
        stertB.OnEne();
        //Level1.OnEne();
        Level2.OnEne();
        Level3.OnEne();
        //Level4.OnEne();
    }
}
