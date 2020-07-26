using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusTyconn
{
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

        public override void InitiliazeSection(CharacterData characterData)
        {

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

        public void HandleCurrentSessionCourseSelection(CurrentCourseCardViewButton courseSelectionButton)
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
}
