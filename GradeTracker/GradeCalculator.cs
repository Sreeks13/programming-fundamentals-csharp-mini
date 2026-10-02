using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeTracker;

public static class GradeCalculator
{
    public static double CalculateAverage(List<Student> students)
    {
        if (students == null || students.Count == 0)
            return 0;

        return students.Average(s => s.Score);
    }

    public static double GetHighestScore(List<Student> students)
    {
        if (students == null || students.Count == 0)
            return 0;

        return students.Max(s => s.Score);
    }

    public static double GetLowestScore(List<Student> students)
    {
        if (students == null || students.Count == 0)
            return 0;

        return students.Min(s => s.Score);
    }

    public static Student? FindStudent(List<Student> students, string name)
    {
        if (students == null || string.IsNullOrWhiteSpace(name))
            return null;

        return students.FirstOrDefault(
            s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public static string GetGrade(double score)
    {
        if (score >= 90)
            return "A";
        if (score >= 80)
            return "B";
        if (score >= 70)
            return "C";
        if (score >= 60)
            return "D";

        return "F";
    }
}