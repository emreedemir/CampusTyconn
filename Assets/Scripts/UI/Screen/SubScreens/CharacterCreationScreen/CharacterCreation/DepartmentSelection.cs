using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DepartmentSelection : BaseSelection
{
    List<DepartmentSelectionButton> departmentSelectionButtons;

    DepartmentSelectionButton selectedDepartmentButton;

    public Transform departmentListViewParent;

    public DepartmentSelectionButton departmentSelectionButtonPrefab;

    public Action<Department> OnDepartmentSelected;

    public Action<string> OnMessageReleased;

    private void Start()
    {
        Initiliaze();
    }

    public override void Initiliaze()
    {
        departmentSelectionButtons = new List<DepartmentSelectionButton>();

        List<Department> allDepartment = FindObjectOfType<ResourcesController>().GetAllDepartments();

        Debug.Log("Department countt" + allDepartment.Count);

        for (int i = 0; i < allDepartment.Count; i++)
        {
            DepartmentSelectionButton dsb = Instantiate(departmentSelectionButtonPrefab, departmentListViewParent);

            dsb.transform.SetParent(departmentListViewParent);

            dsb.SetDepartmentSelectionButton(allDepartment[i]);

            departmentSelectionButtons.Add(dsb);

            dsb.OnDepartmentSelectionButtonPressed += OnDepartmentSelected;
        }
    }

    public void HandleDepartmentSelection(Department department)
    {
        DepartmentSelectionButton selectionButton = departmentSelectionButtons.Find(x => x.department.Equals(department));

        Debug.Log("Department selected");

        if (selectedDepartmentButton != null)
        {
            if (selectedDepartmentButton != selectionButton)
            {
                selectedDepartmentButton.MarkAsDeselected();

                OnDepartmentSelected?.Invoke(department);

                selectedDepartmentButton = selectionButton;

                selectedDepartmentButton.MarkAsSelected();
            }
            else
            {
                OnMessageReleased?.Invoke("Already Select Department");
            }
        }
        else
        {
            selectedDepartmentButton = selectionButton;

            OnDepartmentSelected?.Invoke(department);

            selectedDepartmentButton.MarkAsSelected();
        }
    }

    public override bool selectionCompleted()
    {
        return selectedDepartmentButton != null;
    }

    public override void NotCompletedMessage()
    {
        OnMessageReleased?.Invoke("Please Select Department");
    }
}
