using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationScreen : BaseScreen
{
    public BasicButton skipNextButton;

    public BasicButton skipBackButton;

    public List<BaseSelection> selection;

    BaseSelection currentSelectionScreen;

    public CharacterCreation character;

    public Character characterC;

    private void Start()
    {
        InitilizaeScreen();
    }

    public override void InitilizaeScreen()
    {

        skipNextButton.OnButtonPressed += OnSkipNextButtonPressed;

        skipBackButton.OnButtonPressed += OnSkipBackButtonPressed;


        currentSelectionScreen = selection[0];

        character = new CharacterCreation();
    }

    public void OnSkipNextButtonPressed()
    {
        if (currentSelectionScreen != null)
        {
            if (currentSelectionScreen.selectionCompleted())
            {
                SkipNext();
            }
        }
    }

    public void OnSkipBackButtonPressed()
    {
        int indexCurrent = selection.FindIndex(a => a == currentSelectionScreen);

        if (indexCurrent > selection.Count)
        {
            BaseSelection backSelection = selection[indexCurrent];

            SlideScreen.Instance.SlideScreens(currentSelectionScreen.gameObject.transform, backSelection.gameObject.transform, SlideType.ToLeft);

            //currentSelectionScreen = backSelection;
        }
        else
        {
            Debug.Log("This is first selection");
        }
    }

    public void SkipNext()
    {
        Debug.Log("Skip Next");

        int indexCurrent = selection.FindIndex(a => a == currentSelectionScreen);

        if (indexCurrent <= (selection.Count - 2))
        {
            Debug.Log("Sekme açıldı" + indexCurrent);
            BaseSelection nextSelection = selection[indexCurrent + 1];

            SlideScreen.Instance.SlideScreens(currentSelectionScreen.gameObject.transform, nextSelection.gameObject.transform, SlideType.ToLeft);

            currentSelectionScreen = nextSelection;
        }
        else
        {
            CharacterCreationFormCompleted();
        }
    }
    public void CharacterCreationFormCompleted()
    {
        Debug.Log("Character created");
        FindObjectOfType<GameController>().CreateNewCharacter(characterC);

        //Set to Game Play Screen
    }

}

public class CharacterCreation
{
    public Gender gender;

    public string nameAndSurname = "";

    public string countryName = "";

    public string universityName = "";

    public string departmentName = "";
}
