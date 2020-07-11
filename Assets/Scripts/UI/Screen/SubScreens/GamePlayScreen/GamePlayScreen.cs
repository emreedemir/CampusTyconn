using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GamePlayScreen : BaseScreen
{
    public BasicButton gameExitButton;

    public GameSectionButton characterSectionButton;

    public GameSectionButton socialSectionButton;

    public GameSectionButton schollSectionButton;

    public GameSectionButton enterpriseSectionButton;

    public List<GameSection> allGameSections;

    private GameSection currentGameSection;

    public Character currentCharacter;

    private void Start()
    {
        InitilizaeScreen();
    }

    public override void InitilizaeScreen()
    {
        gameExitButton.OnButtonPressed += OnGameExitButtonPressed;

        socialSectionButton.SetGameSectionButton(allGameSections.Find(x => x is SocialSection));

        socialSectionButton.OnPressed += HandleSectionButtonPressed;

        characterSectionButton.SetGameSectionButton(allGameSections.Find(x => x is CharacterSection));

        characterSectionButton.OnPressed += HandleSectionButtonPressed;

        schollSectionButton.SetGameSectionButton(allGameSections.Find(x => x is SchoolSection));

        schollSectionButton.OnPressed += HandleSectionButtonPressed;

        enterpriseSectionButton.SetGameSectionButton(allGameSections.Find(x => x is EnterpriseSection));

        enterpriseSectionButton.OnPressed += HandleSectionButtonPressed;

        currentGameSection = allGameSections.Find(x => x is CharacterSection);
    }

    public void SetGamePlay()
    {
    }


    public void HandleSectionButtonPressed(GameSection gameSection)
    {
        SlideScreen.Instance.SlideScreens(currentGameSection.transform, gameSection.transform, SlideType.ToLeft);

        currentGameSection = gameSection;
    }

    public void OnGameExitButtonPressed()
    {

    }

    public void BackToGameMainScreen()
    {

    }
}
