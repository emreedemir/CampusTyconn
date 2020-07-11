using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurrentCourseCardViewButton : MonoBehaviour, IPointerClickHandler
{
    public Text courseName;

    public Text workedHourText;

    public Action<CurrentCourseCardViewButton> OnPressed;

    public Action OnProgressStarted;

    public Action OnProgressFinished;

    public Course course;

    public void SetCurrentCourseCardViewButton(Course course)
    {
        this.course = course;

        courseName.text = course.courseName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke(this);     
    }

    public void StartWorkProgress()
    {
        StartCoroutine(WorkCoroutine(1));
    }

    IEnumerator WorkCoroutine(int workTime)
    {
        GetComponent<Image>().color = Color.green;

        FindObjectOfType<CharacterController>().InProgress = true;

        yield return new WaitForSeconds(workTime);

        FindObjectOfType<CharacterController>().InProgress = false;
        GetComponent<Image>().color = Color.white;

        NotifyMissionFinish();
    }

    public void NotifyMissionFinish()
    {
        OnProgressFinished?.Invoke();
    }

}
