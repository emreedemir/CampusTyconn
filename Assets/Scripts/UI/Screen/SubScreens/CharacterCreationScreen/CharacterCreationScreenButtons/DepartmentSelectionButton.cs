using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DepartmentSelectionButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public Department department;

    public Text departmentNameTextView;

    public Action<Department> OnDepartmentSelectionButtonPressed;

    public void SetDepartmentSelectionButton(Department department)
    {
        this.department = department;

        departmentNameTextView.text = department.departmentName;
    }

    public void MarkAsSelected()
    {
        GetComponent<Image>().color = Color.red;
    }

    public void MarkAsDeselected()
    {
        GetComponent<Image>().color = Color.blue;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Department selection button clicked");

        OnDepartmentSelectionButtonPressed?.Invoke(department);
    }
}
