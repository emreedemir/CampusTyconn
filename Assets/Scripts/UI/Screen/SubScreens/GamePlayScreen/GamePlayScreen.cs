using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreen : BaseScreen
{
    public BasicButton schoolButton;

    public BasicButton EnterpriseButton;

    public BasicButton socialButton;

    public MainCharacterScreen mainCharacterScreen;

    public SchoolScreen schoolScreen;

    public SocialScreen socialScreen;

    public EnterpriseScreen enterpriseScreen;

    public override void InitilizaeScreen()
    {

    }

    public void OpenMainCharacterScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, mainCharacterScreen.gameObject.transform, SlideType.ToLeft);
    }

    public void OpenSchoolScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, schoolScreen.transform, SlideType.ToLeft);
    }

    public void OpenSocialScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, socialScreen.transform, SlideType.ToLeft);
    }

    public void OpenEnterpriseScreen(Transform current)
    {
        SlideScreen.Instance.SlideScreens(current, enterpriseScreen.transform, SlideType.ToRight);
    }

    public void BackToGameMainScreen()
    {

    }
}
