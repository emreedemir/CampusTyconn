using System;

[Serializable]
public struct Course
{
    public string courseName;

    public int difficulty;

    public int workedHour;

    public string note;

    public bool passed;

    public Course(string courseName, int difficulty, int workedHour, string note, bool passed)
    {
        this.courseName = courseName;
        this.difficulty = difficulty;
        this.workedHour = workedHour;
        this.note = note;
        this.passed = passed;
    }
}
