using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class GenderButton : MonoBehaviour,IPointerClickHandler
{
    public Gender gender;

    public Action<Gender> OnClicked;

    public void SetGenderButton(Gender gender)
    {
        this.gender = gender;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked?.Invoke(gender);
    }
}
