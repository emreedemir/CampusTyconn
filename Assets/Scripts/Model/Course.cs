using System;

[Serializable]
public struct Course
{
    public string courseName;

    public int difficulty;

    public Course(string courseName, int difficulty)
    {
        this.courseName = courseName;
        this.difficulty = difficulty;
    }
}
