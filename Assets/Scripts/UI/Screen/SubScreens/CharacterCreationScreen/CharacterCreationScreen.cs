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

    public Character character;

    public CharacterCreationMessageBox characterCreationMessageBox;

    private void Start()
    {
        InitilizaeScreen();
    }

    public override void InitilizaeScreen()
    {
        skipNextButton.OnButtonPressed += OnSkipNextButtonPressed;

        skipBackButton.OnButtonPressed += OnSkipBackButtonPressed;

        currentSelectionScreen = selection[0];

        character = new Character();

        character.characterName = "";
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
        FindObjectOfType<GameController>().CreateNewCharacter(character);

        FindObjectOfType<MainScreensController>().OpenMainGamePlayScreen(this.transform);
    }

    public void OnMessageReleased(string message)
    {
        characterCreationMessageBox.NotifyMessage(message);
    }
}