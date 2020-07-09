using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelection : BaseSelection
{
    public GenderButton menButton;

    public GenderButton womanButton;

    private void Start()
    {
        Initiliaze();
    }

    public override void Initiliaze()
    {
        menButton.gender = Gender.Man;

        menButton.OnClicked += OnGenderSelected;

        womanButton.gender = Gender.Woman;

        womanButton.OnClicked += OnGenderSelected;
    }

    public void OnGenderSelected(Gender gender)
    {
        Debug.Log("On Clicke");

        if (gender == Gender.Man)
        {
            FindObjectOfType<CharacterCreationScreen>().character.gender = Gender.Man;
            Debug.Log("Man Gender selected");
        }
        else if (gender == Gender.Woman)
        {

            FindObjectOfType<CharacterCreationScreen>().character.gender = Gender.Man;

            Debug.Log("Woman Gender Selected");
        }
        else
        {
            Debug.Log("Please Select a gender");
        }
    }

    public override bool selectionCompleted()
    {
        return FindObjectOfType<CharacterCreationScreen>().character.gender == Gender.Man || FindObjectOfType<CharacterCreationScreen>().character.gender == Gender.Woman;
    }


}
public enum Gender
{
    None,
    Woman,
    Man
}