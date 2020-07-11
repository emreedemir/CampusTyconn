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

    public Action<int> OnPressed;

    public Action OnProgressFinished;

    Course course;

    public void SetCurrentCourseCardViewButton(Course course)
    {
        this.course = course;

        courseName.text = course.courseName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FindObjectOfType<CharacterController>().InProgress == false)
        {
            if (course.workedHour < course.difficulty)
            {
                course.workedHour += 1;
                StartCoroutine(WorkCoroutine(1));
            }
            else
            {
                FindObjectOfType<GamePlayScreen>().NotifyMessage("You enough worked");
            }
        }
        else
        {
            FindObjectOfType<GamePlayScreen>().NotifyMessage("Wait Character On Progress!");
        }
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
