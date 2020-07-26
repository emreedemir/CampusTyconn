using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusTyconn;
using System.Linq;

public class CharacterCreationScreen : BaseScreen
{
    public BasicButton skipNextButton;

    public BasicButton skipBackButton;

    public List<BaseSelection> selection;

    private BaseSelection currentSelectionScreen;

    public CharacterCreationMessageBox characterCreationMessageBox;

    CharacterCreationData characterCreationData;

    private void Start()
    {
        InitilizaeScreen();
    }

    public override void InitilizaeScreen()
    {
        characterCreationData = new CharacterCreationData();

        selection.ForEach(x => x.Initiliaze());

        skipNextButton.OnButtonPressed += OnSkipNextButtonPressed;

        skipBackButton.OnButtonPressed += OnSkipBackButtonPressed;

        NameSelection nameSelection = selection.OfType<NameSelection>().First();

        nameSelection.OnNameFill += HandleNameFill;

        GenderSelection genderSelection = selection.OfType<GenderSelection>().First();

        genderSelection.OnGenderSelect += HandleGenderSelection;

        DepartmentSelection departmentSelection = selection.OfType<DepartmentSelection>().First();

        departmentSelection.OnDepartmentSelected += HandleDepartmentSelection;

        foreach (BaseSelection selection in selection)
        {
            selection.OnMessageReleased += HandleMessageReleased;
        }

        currentSelectionScreen = selection[0];

    }

    public void OnSkipNextButtonPressed()
    {
        if (currentSelectionScreen != null)
        {
            if (currentSelectionScreen.SelectionCompleted(characterCreationData))
            {
                int indexCurrent = selection.FindIndex(a => a == currentSelectionScreen);

                if (indexCurrent <= (selection.Count - 2))
                {
                    BaseSelection nextSelection = selection[indexCurrent + 1];

                    SlideScreen.Instance.SlideScreens(currentSelectionScreen.gameObject.transform, nextSelection.gameObject.transform, SlideType.ToLeft);

                    currentSelectionScreen = nextSelection;
                }
                else
                {
                    CharacterCreationFormCompleted();
                }
            }
            else
            {
                HandleMessageReleased("Fill Correctly");
            }
        }
    }

    public void OnSkipBackButtonPressed()
    {
        int indexCurrent = selection.FindIndex(a => a == currentSelectionScreen);

        if (indexCurrent > 0)
        {
            BaseSelection backSelection = selection[indexCurrent - 1];

            SlideScreen.Instance.SlideScreens(currentSelectionScreen.gameObject.transform, backSelection.gameObject.transform, SlideType.ToRight);

            currentSelectionScreen = backSelection;
        }
        else
        {
            Debug.Log("This is first selection");
        }
    }

    public void HandleNameFill(string name)
    {
        characterCreationData.name = name;
    }

    public void HandleGenderSelection(Gender gender)
    {
        Debug.Log("Gender Selected");
        characterCreationData.gender = gender;
    }

    public void HandleDepartmentSelection(Department department)
    {
        Debug.Log("Department Selected");

        characterCreationData.department = department;
    }

    public void CharacterCreationFormCompleted()
    {
        GameController.Instance.CreateNewCharacter(characterCreationData);
    }

    public void HandleMessageReleased(string message)
    {
        characterCreationMessageBox.NotifyMessage(message);
    }
}

public class CharacterCreationData
{
    public Gender gender;

    public Department department;

    public string name;

    public CharacterCreationData()
    {
        gender = Gender.None;
        name = "";
        department = new Department();

    }
}
