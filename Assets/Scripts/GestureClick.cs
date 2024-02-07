using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GestureClick : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<Vector3> OnClick;
    public event Action PositionChanged;

    public void OnPointerClick(PointerEventData eventData)
    {
        PositionChanged?.Invoke();
        OnClick.Invoke(eventData.pointerPressRaycast.worldPosition);
    }
}

