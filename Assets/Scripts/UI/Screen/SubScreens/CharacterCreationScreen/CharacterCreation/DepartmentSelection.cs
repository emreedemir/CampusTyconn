using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepartmentSelection : BaseSelection
{
    List<DepartmentSelectionButton> departmentSelectionButtons;

    DepartmentSelectionButton selectedDepartmentButton;

    public Transform departmentListViewParent;

    public DepartmentSelectionButton departmentSelectionButtonPrefab;

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

    public void OnDepartmentSelected(Department department)
    {
        DepartmentSelectionButton selectionButton = departmentSelectionButtons.Find(x => x.department.Equals(department));

        Debug.Log("Department selected");

        if (selectedDepartmentButton != null)
        {
            if (selectedDepartmentButton != selectionButton)
            {
                selectedDepartmentButton.MarkAsDeselected();

                FindObjectOfType<CharacterCreationScreen>().character.SetDepartment(department);

                selectedDepartmentButton = selectionButton;

                selectedDepartmentButton.MarkAsSelected();
            }
        }
        else
        {
            selectedDepartmentButton = selectionButton;

            FindObjectOfType<CharacterCreationScreen>().character.SetDepartment(department);

            selectedDepartmentButton.MarkAsSelected();
        }
    }

    public override bool selectionCompleted()
    {
        Department department = FindObjectOfType<CharacterCreationScreen>().character.department;

        if (departmentSelectionButtons.Find(x => x.department.Equals(department)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void NotCompletedMessage()
    {
        FindObjectOfType<CharacterCreationScreen>().OnMessageReleased("Please Selecte Department");
    }
}
