using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusTyconn
{
    public class SchoolSection : GameSection
    {
        public Transform currentCoursesScreenParent;

        public Transform allCoursesScreenParent;

        public BasicButton currentCoursesButton;

        public BasicButton allCoursesButton;

        public CurrentCourseCardViewButton currentCourseCardViewButtonPrefab;

        public CourseSelectionButton courseSelectionButtonPrefab;

        public List<CurrentCourseCardViewButton> allCurrentCourseCardViewButtons;

        public List<CourseSelectionButton> allCourseSelectionButtons;

        public override void InitiliazeSection(CharacterData characterData)
        {
            SetCurrentCoursesScreen(characterData.department.currentCourses);

            SetAllCoursesScreen(characterData.department.courses);
        }

        public void SetCurrentCoursesScreen(Course[] currentCourses)
        {
            allCurrentCourseCardViewButtons = new List<CurrentCourseCardViewButton>();

            for (int i = 0; i < currentCourses.Length; i++)
            {
                CurrentCourseCardViewButton cvb = Instantiate(currentCourseCardViewButtonPrefab);

                cvb.SetCurrentCourseCardViewButton(currentCourses[i]);

                cvb.transform.SetParent(currentCoursesScreenParent.transform);

                allCurrentCourseCardViewButtons.Add(cvb);
            }
        }

        public void SetAllCoursesScreen(Course[] courses)
        {
            allCourseSelectionButtons = new List<CourseSelectionButton>();

            for (int i = 0; i < courses.Length; i++)
            {
                CourseSelectionButton csb = Instantiate(courseSelectionButtonPrefab);

                csb.transform.SetParent(allCoursesScreenParent.transform);

                csb.SetCourseSelectionButton(courses[i]);

                allCourseSelectionButtons.Add(csb);
            }
        }

        public void HandleCurrentSessionCourseSelection(CurrentCourseCardViewButton courseSelectionButton)
        {
            Course course = courseSelectionButton.course;

            if (course.workedHour >= course.difficulty)
            {
                ReleaseMessage("You dont need to work anymore");
            }
            else
            {
                course.workedHour++;

                ReleaseMessage("Productive hard times");

                if (course.workedHour ==course.difficulty)
                {
                    courseSelectionButton.MarkAsFullTimeWorked();
                }

            }
        }

        public void HandleCourseSelection(CourseSelectionButton courseSelectionButton)
        {

        }

        public void OnPressedCurrentCoursesButton()
        {
            SlideScreen.Instance.SlideScreens(allCoursesScreenParent.gameObject.transform, currentCoursesScreenParent.gameObject.transform, SlideType.ToRight);
        }

        public void OnPressedAllCoursesButton()
        {
            SlideScreen.Instance.SlideScreens(currentCoursesScreenParent.gameObject.transform, allCoursesScreenParent.gameObject.transform, SlideType.ToLeft);
        }

        public void NotifySectionMessage(string message)
        {

        }

        public override void ReleaseMessage(string messega)
        {
            base.OnGameSectionMessageReleased?.Invoke(messega);
        }
    }
}
