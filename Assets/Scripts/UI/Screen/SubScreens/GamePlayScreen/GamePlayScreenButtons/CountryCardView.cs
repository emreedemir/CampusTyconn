using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class CountryCardView : MonoBehaviour, IPointerClickHandler
{
    public Action<string> OnCountryCardViewClicked;

    public Sprite flagSprite;

    public string countryName;

    public Text economy;


    public Text freedoom;

    public Text humanity;

    public void SetCountryCardView(Country country)
    {
        flagSprite = Resources.Load<Sprite>("Flags/"+country.countryName+"image");

        economy.text = ""+country.economy;

        freedoom.text = ""+country.freedom;

        humanity.text = "" + country.humanity;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCountryCardViewClicked?.Invoke(countryName);
    }
}
