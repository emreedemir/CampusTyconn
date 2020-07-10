using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountrySelection : BaseSelection
{
    public List<CountrySelectionButton> countrySelectionButtons;

    CountrySelectionButton selectedCountrySelectionButton;

    public Text countryEconomy;

    public Text countryFreedom;

    public Text countryHumanity;

    private void Start()
    {
        Initiliaze();
    }

    public override void Initiliaze()
    {
        List<Country> allCountries = FindObjectOfType<ResourcesController>().GetAllCountries();

        for (int i = 0; i < allCountries.Count; i++)
        {
            countrySelectionButtons[i].SetCountrySelectionButton(allCountries[i]);

            countrySelectionButtons[i].OnCountrySelectionButtonPressed += OnCountrySelected;
        }
    }

    public void OnCountrySelected(Country country)
    {
        FindObjectOfType<CharacterCreationScreen>().character.country = country;

        selectedCountrySelectionButton = countrySelectionButtons.Find(x => x.country.Equals(country));

        FillCountryNotificationPanel();
    }

    void FillCountryNotificationPanel()
    {
        if (selectedCountrySelectionButton != null)
        {
            Country country = selectedCountrySelectionButton.country;

            countryEconomy.text = "Country Economy " + country.economy;

            countryFreedom.text = "Country Freedom " + country.freedom;

            countryHumanity.text = "Country Humanity " + country.humanity;
        }
    }

    public override bool selectionCompleted()
    {
        Country country = FindObjectOfType<CharacterCreationScreen>().character.country;

        if (countrySelectionButtons.Find(x => x.country.Equals(country)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void NotCompletedMessage()
    {
        FindObjectOfType<CharacterCreationScreen>().OnMessageReleased("Please Select Country");
    }
}
