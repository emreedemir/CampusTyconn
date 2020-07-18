using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusTyconn;

public class CharacterCreationScreen : BaseScreen
{
    public BasicButton skipNextButton;

    public BasicButton skipBackButton;

    public List<BaseSelection> selection;

    BaseSelection currentSelectionScreen;

    public CharacterCreationMessageBox characterCreationMessageBox;

    public CharacterData characterData;


    private void Start()
    {
        InitilizaeScreen();
    }

    public override void InitilizaeScreen()
    {
        skipNextButton.OnButtonPressed += OnSkipNextButtonPressed;

        skipBackButton.OnButtonPressed += OnSkipBackButtonPressed;

        currentSelectionScreen = selection[0];

        characterData = new CharacterData();
    }

    public void OnSkipNextButtonPressed()
    {
        if (currentSelectionScreen != null)
        {
            if (currentSelectionScreen.selectionCompleted())
            {
                SkipNext();
            }
            else
            {
                currentSelectionScreen.NotCompletedMessage();
            }
        }
    }

    public void OnSkipBackButtonPressed()
    {
        int indexCurrent = selection.FindIndex(a => a == currentSelectionScreen);

        if (indexCurrent > 0)
        {
            BaseSelection backSelection = selection[indexCurrent - 1];

            SlideScreen.Instance.SlideScreens(currentSelectionScreen.gameObject.transform, backSelection.gameObject.transform, SlideType.ToLeft);

            currentSelectionScreen = backSelection;
        }
        else
        {
            Debug.Log("This is first selection");
        }
    }

    public void SkipNext()
    {
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
        GameController.Instance.CreateNewCharacter(characterData);

        FindObjectOfType<MainScreensController>().OpenMainGamePlayScreen(this.transform);
    }

    public void OnMessageReleased(string message)
    {
        characterCreationMessageBox.NotifyMessage(message);
    }
}