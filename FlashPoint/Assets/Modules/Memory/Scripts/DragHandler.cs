using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startpos;
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startpos = rectTransform.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData evendata)
    {
        canvasGroup.alpha = 0.8f;
        canvasGroup.blocksRaycasts = false;
        rectTransform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData evendata)
    {
        float dragspeed = 0.01f;
        Vector2 newpos = rectTransform.anchoredPosition + evendata.delta * dragspeed;
        newpos.x = Mathf.Clamp(newpos.x, -8f, 8.73f);
        newpos.y = Mathf.Clamp(newpos.y, -3.5f, 4f);
        rectTransform.anchoredPosition = newpos;
    }
    public void OnEndDrag(PointerEventData evendata)
    {
        GameObject drag = evendata.pointerEnter;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (!drag.CompareTag("Select"))
        {
            rectTransform.anchoredPosition = startpos;
        }
    }
}
