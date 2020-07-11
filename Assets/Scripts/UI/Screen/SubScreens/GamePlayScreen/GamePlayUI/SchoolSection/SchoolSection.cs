using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolSection: GameSection
{
    public Transform currentCoursesScreen;

    public Transform allCoursesScreen;

    public CurrentCourseCardViewButton currentCourseCardViewButtonPrefab;

    List<CurrentCourseCardViewButton> allCurrentCourseCardViewButtons;

    public override void InitiliazeSection(Character character)
    {
        allCurrentCourseCardViewButtons = new List<CurrentCourseCardViewButton>();

        for (int i = 0; i < character.department.currentCourses.Length; i++)
        {
            CurrentCourseCardViewButton cvb = Instantiate(currentCourseCardViewButtonPrefab);

            cvb.SetCurrentCourseCardViewButton(character.department.currentCourses[i]);
        }
    }

    public void SetCurrentCoursesScreen()
    {

    }

    public void SetAllCoursesScreen()
    {

    }

    public void OnWorkButtonPressed()
    {

    }

    public void OnCourseSelectButtonPressed()
    {
        
    }
}
