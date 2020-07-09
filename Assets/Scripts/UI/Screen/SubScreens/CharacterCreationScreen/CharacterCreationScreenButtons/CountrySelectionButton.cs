using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CountrySelectionButton : MonoBehaviour, IPointerClickHandler
{
    public Country country;

    public Action<Country> OnCountrySelectionButtonPressed;

    public void SetCountrySelectionButton(Country country)
    {
        this.country = country;

        Sprite flagSprite = FindObjectOfType<ResourcesController>().GetFlagSprite(country.countryName);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCountrySelectionButtonPressed?.Invoke(country);
    }

    public void MarkAsSelected()
    {
        GetComponent<Image>().color = Color.red;
    }


    public void MarkAsDeselected()
    {
        GetComponent<Image>().color = Color.yellow;
    }
}
