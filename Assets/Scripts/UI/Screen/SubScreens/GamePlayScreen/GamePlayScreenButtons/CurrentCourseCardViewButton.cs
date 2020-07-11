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

    public void SetCurrentCourseCardViewButton(Course course)
    {
        courseName.text = course.courseName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (3 == 5)
        {
            OnPressed?.Invoke(1);
        }
    }

    public void SetWorkHours()
    {

    }

    public void MarkAsPressed()
    {
        StartCoroutine(WorkCoroutine(5));
    }

    IEnumerator WorkCoroutine(int workTime)
    {
        GetComponent<Image>().color = Color.green;

        yield return new WaitForSeconds(workTime);

        GetComponent<Image>().color = Color.white;

        NotifyMissionFinish();
    }

    public void NotifyMissionFinish()
    {
        OnProgressFinished?.Invoke();
    }
}
