using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CampusTyconn;

public class MainScreensController : MonoBehaviour
{
    public MainMenu mainMenu;

    public CharacterCreationScreen characterCreationScreen;

    public GamePlayScreen gamePlayScreen;

    public OptionsScreen optionScreen;


    public void OpenCharacterCreationScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, characterCreationScreen.transform, SlideType.ToLeft);
    }

    public void OpenMainScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, mainMenu.transform, SlideType.ToLeft);
    }

    public void OpenMainGamePlayScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, gamePlayScreen.transform, SlideType.ToLeft);
    }

    public void OpenOptionsScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, optionScreen.transform, SlideType.ToLeft);
    }
}
