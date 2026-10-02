using System.Globalization;

namespace GradeTracker;

public static class Program
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("=== Student Grade Tracker ===");

        List<Student> students = EnterStudents();

        PrintReport(students);

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Search student");
            Console.WriteLine("2. Show report");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter student name: ");
                    string? name = Console.ReadLine();

                    Student? student = GradeCalculator.FindStudent(students, name ?? "");

                    if (student == null)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"{student.Name}: {student.Score:F2} - {GradeCalculator.GetGrade(student.Score)}");
                    }

                    break;

                case "2":
                    PrintReport(students);
                    break;

                case "3":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public static List<Student> EnterStudents()
    {
        List<Student> students = new();

        Console.Write("Enter number of students: ");

        if (!int.TryParse(Console.ReadLine(), out int count) || count < 0)
            return students;

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Enter student {i + 1} name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write($"Enter student {i + 1} score: ");

            if (!double.TryParse(
                    Console.ReadLine(),
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out double score))
            {
                score = 0;
            }

            students.Add(new Student(name, score));
        }

        return students;
    }

    public static void PrintReport(List<Student> students)
    {
        Console.WriteLine();
        Console.WriteLine("=== Grade Report ===");

        foreach (Student student in students)
        {
            Console.WriteLine(
                $"{student.Name}: {student.Score:F2} - {GradeCalculator.GetGrade(student.Score)}");
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Average: {GradeCalculator.CalculateAverage(students):F2}");

        Console.WriteLine(
            $"Highest: {GradeCalculator.GetHighestScore(students):F2}");

        Console.WriteLine(
            $"Lowest: {GradeCalculator.GetLowestScore(students):F2}");
    }
}