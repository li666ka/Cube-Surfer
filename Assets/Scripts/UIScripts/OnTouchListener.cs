using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnTouchListener : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public event Action OnTouch;
    public event Action<Touch> OnBeginSwipe;
    public event Action OnEndSwipe;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginSwipe?.Invoke(Input.GetTouch(0));
    }

    //
    public void OnDrag(PointerEventData eventData)
    {
        // important
    }
    //
    
    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndSwipe?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch?.Invoke();
    }
}
