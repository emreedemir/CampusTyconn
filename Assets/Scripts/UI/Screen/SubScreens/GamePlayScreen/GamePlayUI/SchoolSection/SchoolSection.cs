using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolSection : GameSection
{
    public Transform currentCoursesScreen;

    public Transform allCoursesScreen;

    public BasicButton currentCoursesButton;

    public BasicButton allCoursesButton;

    public CurrentCourseCardViewButton currentCourseCardViewButtonPrefab;

    public CourseSelectionButton courseSelectionButtonPrefab;

    public List<CurrentCourseCardViewButton> allCurrentCourseCardViewButtons;

    public List<CourseSelectionButton> allCourseSelectionButtons;

    public override void InitiliazeSection(Character character)
    {
        if (character.department.currentCourses.Length == 0)
        {
            SetCurrentCoursesScreen(character.department);
        }
        else
        {
            NotifySectionMessage("Select Your Courses");
        }

        SetAllCoursesScreen(character.department.courses);
    }

    public void SetCurrentCoursesScreen(Department department)
    {
        allCurrentCourseCardViewButtons = new List<CurrentCourseCardViewButton>();

        for (int i = 0; i < department.currentCourses.Length; i++)
        {
            CurrentCourseCardViewButton cvb = Instantiate(currentCourseCardViewButtonPrefab);

            cvb.SetCurrentCourseCardViewButton(department.currentCourses[i]);         
        }
    }

    public void SetAllCoursesScreen(Course[] courses)
    {
        allCourseSelectionButtons = new List<CourseSelectionButton>();

        for (int i = 0; i < courses.Length; i++)
        {
            CourseSelectionButton csb = Instantiate(courseSelectionButtonPrefab);

            csb.SetCourseSelectionButton(courses[i]);

            allCourseSelectionButtons.Add(csb);
        }
    }

    public void HandleCurrentCourseSelection(CurrentCourseCardViewButton currentCourseCardViewButton)
    {
        if (FindObjectOfType<CharacterController>().InProgress == false)
        {
            if (!currentCourseCardViewButton.course.IsMaximumWorked())
            {
               FindObjectOfType<CharacterController>().currentCharacter.CourseWorked(currentCourseCardViewButton.course);

                currentCourseCardViewButton.StartWorkProgress();
            }
            else
            {
                NotifySectionMessage("You dont need work");
            }
        }
        else
        {
            NotifySectionMessage("Character In Progress");
        }
    }

    public void HandleProgressStart()
    {

    }

    public void HandleProgressFinish()
    {

    }


    public void HandleCourseSelection(CourseSelectionButton courseSelectionButton)
    {

    }

    public void OnPressedCurrentCoursesButton()
    {
        SlideScreen.Instance.SlideScreens(allCoursesScreen.gameObject.transform, currentCoursesScreen.gameObject.transform, SlideType.ToRight);
    }

    public void OnPressedAllCoursesButton()
    {
        SlideScreen.Instance.SlideScreens(currentCoursesScreen.gameObject.transform, allCoursesScreen.gameObject.transform, SlideType.ToLeft);
    }

    public void NotifySectionMessage(string message)
    {

    }
}
