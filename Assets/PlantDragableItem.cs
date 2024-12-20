using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantDragableItem : MonoBehaviour, IEndDragHandler, IPointerClickHandler
{
    public void OnEndDrag(PointerEventData eventData)
    {
        if (this.transform.parent.gameObject.GetComponent<Slot>().planter)
        {
            GetComponent<PlantScript>().PlantSeed();
            Destroy(GetComponent<DragableItem>());
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.transform.parent.gameObject.GetComponent<Slot>().planter)
        {
            GetComponent<PlantScript>().PlantSeed();
            Destroy(GetComponent<DragableItem>());
        }
    }
}
