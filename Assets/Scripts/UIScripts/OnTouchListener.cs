using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnTouchListener : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public event Action Touched;
    public event Action<Touch> BeganDrag;
    public event Action<Touch> Dragging;
    public event Action EndedDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        BeganDrag?.Invoke(Input.GetTouch(0));
    }
    
    public void OnDrag(PointerEventData eventData)
    {

        Dragging?.Invoke(Input.GetTouch(0));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        EndedDrag?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Touched?.Invoke();
    }
}
