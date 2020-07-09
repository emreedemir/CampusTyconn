using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DepartmentCardView : MonoBehaviour
{
    public Action<string> departmentName;

    public Text departmentNameText;

    public Text departmentFee;

    public Text departmentDifficulty;

    public void SetDepartmentCardView(Department department)
    {
        departmentNameText.text = department.departmentName;

        departmentFee.text = "" + department.departmentFee;

        departmentDifficulty.text = "2";
    }

    public void MarkAsSelelected()
    {

    }

    public void MarkAsDeselected()
    {

    }
}
