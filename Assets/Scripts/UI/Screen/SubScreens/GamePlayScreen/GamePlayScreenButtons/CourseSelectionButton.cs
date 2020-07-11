using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class CourseSelectionButton : MonoBehaviour,IPointerClickHandler
{
    public Action<Course> OnCoursePressed;

    public Course course;

    public Text courseNameText;

    public Text courseGradeText;

    public Text passedText;

    public void SetCourseSelectionButton(Course course)
    {
        this.course = course;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCoursePressed?.Invoke(course);
    }

    public void MarkAsPassed()
    {
        GetComponent<Image>().color = Color.green;
    }

    public void MarkAsFail()
    {
        GetComponent<Image>().color = Color.red;
    }

    public void MarkAsNotPassed()
    {
        GetComponent<Image>().color = Color.grey;
    }
}
