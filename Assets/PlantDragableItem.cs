using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantDragableItem : MonoBehaviour, IEndDragHandler
{
    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(GetComponent<DragableItem>());
    }
}
