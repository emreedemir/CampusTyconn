using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using CampusTyconn;

using UnityEngine.UI;

namespace CampusTyconn
{
    public class GamePlayScreen : BaseScreen
    {
        public BasicButton gameExitButton;

        public GameSectionButton characterSectionButton;

        public GameSectionButton socialSectionButton;

        public GameSectionButton schollSectionButton;

        public GameSectionButton enterpriseSectionButton;

        public List<GameSection> allGameSections;

        private GameSection currentGameSection;

        public Text characterNameText;

        public override void InitilizaeScreen()
        {
            for (int i = 0; i < allGameSections.Count; i++)
            {
                allGameSections[i].InitiliazeSection(GameController.Instance.characterData);
            }

            ///DAHA SONRA DÜZELT
            //characterSectionButton.GetComponent<Image>().sprite = FindObjectOfType<ResourcesController>().GetCharacterImage(GameController.Instance.characterData.gender);

            characterNameText.text = GameController.Instance.characterData.name;

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

            Debug.Log("Game Sections İnitiliazed");
        }

        public void NotifyMessage(string message)
        {
            StartCoroutine(MessageCoroutine(message));
        }

        IEnumerator MessageCoroutine(string message)
        {
            yield return new WaitForSeconds(1f);
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
}

