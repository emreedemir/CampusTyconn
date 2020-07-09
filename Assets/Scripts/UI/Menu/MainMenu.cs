using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public BasicButton newGameButton;

    public BasicButton returnGameButton;

    public BasicButton openOptionButton;

    private void Start()
    {
        InitilizaeMainScreen();
    }

    void InitilizaeMainScreen()
    {
        newGameButton.OnButtonPressed += OnNewGameButtonPressed;

        returnGameButton.OnButtonPressed += OnReturnGameButtonPressed;

        openOptionButton.OnButtonPressed += OnOpenOptionsButtonPressed;

    }

    public void OnNewGameButtonPressed()
    {
        FindObjectOfType<MainScreensController>().OpenCharacterCreationScreen(this.transform);
    }

    public void OnReturnGameButtonPressed()
    {
        FindObjectOfType<MainScreensController>().OpenMainGamePlayScreen(this.transform);
    }

    public void OnOpenOptionsButtonPressed()
    {
        FindObjectOfType<MainScreensController>().OpenOptionsScreen(this.transform);
    }
}
