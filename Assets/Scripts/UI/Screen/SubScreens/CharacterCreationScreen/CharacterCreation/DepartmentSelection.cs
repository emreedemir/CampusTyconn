using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace CampusTyconn
{
    public class DepartmentSelection : BaseSelection
    {
        List<DepartmentSelectionButton> departmentSelectionButtons;

        DepartmentSelectionButton selectedDepartmentButton;

        public Transform departmentListViewParent;

        public DepartmentSelectionButton departmentSelectionButtonPrefab;

        public Action<Department> OnDepartmentSelected;

        public Text departmentInfo;

        public override void Initiliaze()
        {
            departmentSelectionButtons = new List<DepartmentSelectionButton>();

            List<Department> allDepartment = FindObjectOfType<ResourcesController>().GetAllDepartments();

            for (int i = 0; i < allDepartment.Count; i++)
            {
                DepartmentSelectionButton dsb = Instantiate(departmentSelectionButtonPrefab, departmentListViewParent);

                dsb.transform.SetParent(departmentListViewParent);

                dsb.SetDepartmentSelectionButton(allDepartment[i]);

                departmentSelectionButtons.Add(dsb);

                dsb.OnDepartmentSelectionButtonPressed += HandleDepartmentSelection;
            }
        }

        public void HandleDepartmentSelection(DepartmentSelectionButton departmentSelectionButton)
        {
            if (selectedDepartmentButton != null)
            {
                if (selectedDepartmentButton != departmentSelectionButton)
                {
                    selectedDepartmentButton.MarkAsDeselected();

                    OnDepartmentSelected?.Invoke(departmentSelectionButton.department);

                    selectedDepartmentButton = departmentSelectionButton;

                    selectedDepartmentButton.MarkAsSelected();

                    ViewDepartmentInfo(selectedDepartmentButton.department);
                }
                else
                {
                    OnMessageReleased?.Invoke("Already Selected Department");
                }
            }
            else
            {
                Debug.Log("Dpartment ilk defa seçildi");

                selectedDepartmentButton = departmentSelectionButton;

                OnDepartmentSelected?.Invoke(departmentSelectionButton.department);

                selectedDepartmentButton.MarkAsSelected();

                ViewDepartmentInfo(selectedDepartmentButton.department);

            }
        }

        public override bool SelectionCompleted(CharacterCreationData characterCreationData)
        {
            if (selectedDepartmentButton == null)
            {
                OnMessageReleased?.Invoke("Select A Department");
                return false;
            }

            return characterCreationData.department.Equals(selectedDepartmentButton.department);
        }


        private void ViewDepartmentInfo(Department department)
        {
            int hardnessOfDepartment = 0;

            for (int i = 0; i < department.currentCourses.Length; i++)
            {
                hardnessOfDepartment += department.currentCourses[i].difficulty;
            }
            hardnessOfDepartment /= department.currentCourses.Length;

            departmentInfo.text = "Difficult of Department " + hardnessOfDepartment;
        }
    }

}
