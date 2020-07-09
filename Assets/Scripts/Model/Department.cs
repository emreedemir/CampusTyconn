using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Department
{
    public string departmentName;

    public float departmentFee;

    public Course[] courses;

    public Department(string departmentName, float departmentFee, Course[] courses)
    {
        this.departmentName = departmentName;
        this.departmentFee = departmentFee;
        this.courses = courses;
    }

    public override string ToString()
    {
        return departmentName + departmentFee;
    }
}
