using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;
    private float firstInputMouse = 0.0f;
    private float LastScrollBar = 0.0f;
    public Transform ScrollBarG;
    public float BarrierTop = 0.0f; 
    public float BarrierBottom = 0.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        firstInputMouse = Input.mousePosition.y - ScrollBarG.localPosition.y;
        LastScrollBar = Input.mousePosition.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }

    void Update()
    {
        if (isHolding)
        {
            if (Input.mousePosition.y > LastScrollBar)
            {
                if (ScrollBarG.localPosition.y < BarrierTop)
                {
                    ScrollBarG.localPosition = new Vector2(ScrollBarG.localPosition.x, (Input.mousePosition.y - firstInputMouse));
                }
            }
            if (Input.mousePosition.y < LastScrollBar)
            {
                if (ScrollBarG.localPosition.y > BarrierBottom)
                {
                    ScrollBarG.localPosition = new Vector2(ScrollBarG.localPosition.x, (Input.mousePosition.y - firstInputMouse));
                }
            }

        }
    }
}