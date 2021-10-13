using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VJRotation : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public void OnDrag(PointerEventData ped)
    {

    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        
    }
}
