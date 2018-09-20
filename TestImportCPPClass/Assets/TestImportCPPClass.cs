using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TestImportCPPClass : MonoBehaviour
{
    [DllImport("TestExportCPPClass")]
    public static extern IntPtr Student_Create();

    [DllImport("TestExportCPPClass")]
    public static extern void Student_SetScore(IntPtr value, int score);

    [DllImport("TestExportCPPClass")]
    public static extern int Student_GetGrade(IntPtr value);

    [DllImport("TestExportCPPClass")]
    public static extern void Student_Delete(IntPtr value);

    void Start()
    {
        int[] scores = {20, 40, 50, 56, 60, 75, 85, 100};
        IntPtr[] students = new IntPtr[scores.Length];
        for (int i = 0; i < students.Length; i++)
        {
            int score = scores[i];
            students[i] = Student_Create();
            Student_SetScore(students[i], score);
        }

        for (int i = 0; i < students.Length; i++)
        {
            int grade = Student_GetGrade(students[i]);
            Debug.Log("Score: " + scores[i] + " Grade: " + grade);
            Student_Delete(students[i]);
        }
    }
}