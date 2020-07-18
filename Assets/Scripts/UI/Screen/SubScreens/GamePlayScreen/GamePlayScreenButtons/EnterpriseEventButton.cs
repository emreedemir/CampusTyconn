using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EnterpriseEventButton : MonoBehaviour, IPointerClickHandler
{
    public int increaseValue;

    public bool timeNeed;

    public Action<int> OnPressed;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke(increaseValue);

    }
}
