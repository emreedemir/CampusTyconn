using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DepartmentEditor : EditorWindow
{
    public static int courseCount = 48;

    Vector2 scrollPos = Vector2.zero;

    public string departmentName = "Department Name";

    public string departmentFee = "0";

    public List<string> courses = new List<string>();

    public List<EditorData<string, string>> editorDatas;

    void OnEnable()
    {
        editorDatas = new List<EditorData<string, string>>();

        for (int i = 0; i < courseCount; i++)
        {
            editorDatas.Add(new EditorData<string, string>("Course Name", "Course Difficulty"));
        }
    }

    [MenuItem("Campustan/Create Department")]
    public static void ShowWindow()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(DepartmentEditor));

        window.minSize = new Vector2(500, 800);
    }

    private void OnGUI()
    {
        GUILayout.Label("Department Name");

        departmentName = GUILayout.TextField(departmentName);

        GUILayout.Label("Department Fee");

        departmentFee = GUILayout.TextField(departmentFee);

        GUILayout.BeginVertical();

        GUILayout.Label("Courses");

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Width(200), GUILayout.Height(400));

        for (int i = 0; i < editorDatas.Count; i++)
        {
            if (i % 6 == 0)
            {
                GUILayout.Label("Session " + (i / 6 + 1));
            }

            GUILayout.Label("Course Name");

            editorDatas[i].val = GUILayout.TextField(editorDatas[i].val);

            GUILayout.Label("Course Difficulty");

            editorDatas[i].val2 = GUILayout.TextField(editorDatas[i].val2);
        }

        GUILayout.EndScrollView();

        GUILayout.EndVertical();

        if (GUILayout.Button("Save Department Infos"))
        {
            CreateDepartment();
        }
    }

    public void CreateDepartment()
    {
        Course[] coursesArray = new Course[courseCount];

        for (int i = 0; i < editorDatas.Count; i++)
        {
            Course course = new Course(editorDatas[i].val, int.Parse(editorDatas[i].val2));

            coursesArray[i] = course;
        }

        float fee = float.Parse(departmentFee);

        Department department = new Department(departmentName, fee, coursesArray);

        SaveDepartmentInfo(department);
    }

    public void SaveDepartmentInfo(Department department)
    {
        string json = JsonUtility.ToJson(department, true);

        string filePath = Application.dataPath + "/" + department.departmentName + ".json";

        Debug.Log(department.ToString());

        File.WriteAllText(filePath, json);

        Debug.Log("Department File Saved");
    }

    public class EditorData<T, G>
    {
        public T val;
        public G val2;

        public EditorData(T val, G val2)
        {
            this.val = val;
            this.val2 = val2;
        }
    }
}
