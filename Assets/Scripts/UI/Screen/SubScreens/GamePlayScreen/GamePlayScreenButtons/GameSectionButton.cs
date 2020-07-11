using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameSectionButton : MonoBehaviour, IPointerClickHandler
{
    public Action<GameSection> OnPressed;

    GameSection section;


    public void SetGameSectionButton(GameSection gameSection)
    {
        this.section = gameSection;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke(section);
    }
}
