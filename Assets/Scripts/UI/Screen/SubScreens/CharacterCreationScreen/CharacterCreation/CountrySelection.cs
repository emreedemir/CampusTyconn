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

        Debug.Log("Country Count" + allCountries.Count);

        for (int i = 0; i < allCountries.Count; i++)
        {
            countrySelectionButtons[i].SetCountrySelectionButton(allCountries[i]);

            countrySelectionButtons[i].OnCountrySelectionButtonPressed += OnCountrySelected;

            Debug.Log("Country Selection initiliazed");
        }
    }

    public void OnCountrySelected(Country country)
    {
        Debug.Log("Country Selected");

        FindObjectOfType<CharacterCreationScreen>().character.countryName = country.countryName;

        selectedCountrySelectionButton = countrySelectionButtons.Find(x => x.country.Equals(country));
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
        return FindObjectOfType<CharacterCreationScreen>().character.countryName != null;
    }
}
