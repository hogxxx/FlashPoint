using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    private GameObject previousarea;
    private bool occupied = false;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;
        if (draggedObject != null && !occupied)
        {
                RectTransform rectTransform = draggedObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                if (previousarea != null)
                {
                    previousarea.GetComponent<DropHandler>().ClearArea();
                }
                occupied = false;
                previousarea = gameObject;
        }
        var generate = FindObjectOfType<Generate>();
        var generate1 = FindObjectOfType<Generate1>();
        var training = FindObjectOfType<Training>();
        if (generate != null)
        {
            generate.Check();
        }
        else if(generate1 != null)
        {
            generate1.Check();
        }
        else if(training != null)
        {
            training.Check();
        }
        else
        {
            Debug.Log("Ни Generate, ни Generate1 не найдены в сцене");
        }
    }
    public void ClearArea()
    {
        occupied = false;
        previousarea = null;
    }
}

