using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class SocialEventButton : MonoBehaviour, IPointerClickHandler
{
    public Action<int> OnPressed;

    public int changedValue;

    public int socialEventCost;

    public int eventTime;

    public Slider slider;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke(changedValue);    
    }

    IEnumerator StartEventCoroutine(int progressTime)
    {       
        yield return new WaitForSeconds(1f);
    }
}
