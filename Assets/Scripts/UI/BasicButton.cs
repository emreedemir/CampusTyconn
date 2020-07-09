using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BasicButton : MonoBehaviour, IPointerClickHandler
{
    public Action OnButtonPressed;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonPressed?.Invoke();
    }
}
