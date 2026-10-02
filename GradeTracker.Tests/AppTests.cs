using GradeTracker;
using Xunit;

namespace GradeTracker.Tests;

public class AppTests
{
    [Fact]
    public void Average_ReturnsCorrectValue()
    {
        var students = new List<Student>
        {
            new("A", 80), new("B", 90), new("C", 70)
        };

        Assert.Equal(80, GradeCalculator.CalculateAverage(students));
    }

    [Fact]
    public void Average_EmptyList_ReturnsZero()
    {
        Assert.Equal(0, GradeCalculator.CalculateAverage(new()));
    }

    [Fact]
    public void Average_NullList_ReturnsZero()
    {
        Assert.Equal(0, GradeCalculator.CalculateAverage(null!));
    }

    [Fact]
    public void Average_SingleStudent()
    {
        Assert.Equal(85, GradeCalculator.CalculateAverage(
            new List<Student> { new("A", 85) }));
    }

    [Fact]
    public void Average_DecimalScore()
    {
        Assert.Equal(85.5, GradeCalculator.CalculateAverage(
            new List<Student> { new("A", 85), new("B", 86) }));
    }

    [Fact]
    public void Highest_ReturnsHighest()
    {
        var students = new List<Student>
        {
            new("A", 70), new("B", 95), new("C", 80)
        };

        Assert.Equal(95, GradeCalculator.GetHighestScore(students));
    }

    [Fact]
    public void Highest_EmptyList_ReturnsZero()
    {
        Assert.Equal(0, GradeCalculator.GetHighestScore(new()));
    }

    [Fact]
    public void Highest_NullList_ReturnsZero()
    {
        Assert.Equal(0, GradeCalculator.GetHighestScore(null!));
    }

    [Fact]
    public void Highest_SingleStudent()
    {
        Assert.Equal(88, GradeCalculator.GetHighestScore(
            new List<Student> { new("A", 88) }));
    }

    [Fact]
    public void Lowest_ReturnsLowest()
    {
        var students = new List<Student>
        {
            new("A", 70), new("B", 95), new("C", 80)
        };

        Assert.Equal(70, GradeCalculator.GetLowestScore(students));
    }

    [Fact]
    public void Lowest_EmptyList_ReturnsZero()
    {
        Assert.Equal(0, GradeCalculator.GetLowestScore(new()));
    }

    [Fact]
    public void Lowest_NullList_ReturnsZero()
    {
        Assert.Equal(0, GradeCalculator.GetLowestScore(null!));
    }

    [Fact]
    public void Lowest_SingleStudent()
    {
        Assert.Equal(88, GradeCalculator.GetLowestScore(
            new List<Student> { new("A", 88) }));
    }

    [Fact]
    public void Grade_100_IsA()
    {
        Assert.Equal("A", GradeCalculator.GetGrade(100));
    }

    [Fact]
    public void Grade_90_IsA()
    {
        Assert.Equal("A", GradeCalculator.GetGrade(90));
    }

    [Fact]
    public void Grade_89_IsB()
    {
        Assert.Equal("B", GradeCalculator.GetGrade(89));
    }

    [Fact]
    public void Grade_80_IsB()
    {
        Assert.Equal("B", GradeCalculator.GetGrade(80));
    }

    [Fact]
    public void Grade_79_IsC()
    {
        Assert.Equal("C", GradeCalculator.GetGrade(79));
    }

    [Fact]
    public void Grade_70_IsC()
    {
        Assert.Equal("C", GradeCalculator.GetGrade(70));
    }

    [Fact]
    public void Grade_69_IsD()
    {
        Assert.Equal("D", GradeCalculator.GetGrade(69));
    }

    [Fact]
    public void Grade_60_IsD()
    {
        Assert.Equal("D", GradeCalculator.GetGrade(60));
    }

    [Fact]
    public void Grade_59_IsF()
    {
        Assert.Equal("F", GradeCalculator.GetGrade(59));
    }

    [Fact]
    public void Grade_0_IsF()
    {
        Assert.Equal("F", GradeCalculator.GetGrade(0));
    }

    [Fact]
    public void Grade_101_IsA()
    {
        Assert.Equal("A", GradeCalculator.GetGrade(101));
    }

    [Fact]
    public void Grade_Negative_IsF()
    {
        Assert.Equal("F", GradeCalculator.GetGrade(-10));
    }

    [Fact]
    public void FindStudent_FindsStudent()
    {
        var students = new List<Student>
        {
            new("Alice", 85),
            new("Bob", 90)
        };

        var result = GradeCalculator.FindStudent(students, "Alice");

        Assert.NotNull(result);
        Assert.Equal(85, result.Score);
    }

    [Fact]
    public void FindStudent_IsCaseInsensitive()
    {
        var students = new List<Student>
        {
            new("Alice", 85)
        };

        Assert.NotNull(GradeCalculator.FindStudent(students, "alice"));
    }

    [Fact]
    public void FindStudent_Missing_ReturnsNull()
    {
        var students = new List<Student>
        {
            new("Alice", 85)
        };

        Assert.Null(GradeCalculator.FindStudent(students, "John"));
    }

    [Fact]
    public void FindStudent_EmptyName_ReturnsNull()
    {
        var students = new List<Student>
        {
            new("Alice", 85)
        };

        Assert.Null(GradeCalculator.FindStudent(students, ""));
    }

    [Fact]
    public void FindStudent_Whitespace_ReturnsNull()
    {
        var students = new List<Student>
        {
            new("Alice", 85)
        };

        Assert.Null(GradeCalculator.FindStudent(students, "   "));
    }

    [Fact]
    public void FindStudent_EmptyList_ReturnsNull()
    {
        Assert.Null(GradeCalculator.FindStudent(new(), "Alice"));
    }

    [Fact]
    public void Student_StoresName()
    {
        var student = new Student("Alice", 85);

        Assert.Equal("Alice", student.Name);
    }

    [Fact]
    public void Student_StoresScore()
    {
        var student = new Student("Alice", 85);

        Assert.Equal(85, student.Score);
    }

    [Fact]
    public void Student_AllowsZeroScore()
    {
        var student = new Student("Alice", 0);

        Assert.Equal(0, student.Score);
    }

    [Fact]
    public void Student_AllowsFullScore()
    {
        var student = new Student("Alice", 100);

        Assert.Equal(100, student.Score);
    }

    [Fact]
    public void FindStudent_ReturnsCorrectStudentAmongDuplicates()
    {
        var students = new List<Student>
        {
            new("Alice", 70),
            new("Bob", 80),
            new("Alice", 90)
        };

        var result = GradeCalculator.FindStudent(students, "Alice");

        Assert.NotNull(result);
        Assert.Equal(70, result.Score);
    }

    [Fact]
    public void Average_MultipleStudents()
    {
        var students = new List<Student>
        {
            new("A", 10),
            new("B", 20),
            new("C", 30),
            new("D", 40)
        };

        Assert.Equal(25, GradeCalculator.CalculateAverage(students));
    }

    [Fact]
    public void Highest_WithNegativeScores()
    {
        var students = new List<Student>
        {
            new("A", -10),
            new("B", -5),
            new("C", -20)
        };

        Assert.Equal(-5, GradeCalculator.GetHighestScore(students));
    }

    [Fact]
    public void Lowest_WithNegativeScores()
    {
        var students = new List<Student>
        {
            new("A", -10),
            new("B", -5),
            new("C", -20)
        };

        Assert.Equal(-20, GradeCalculator.GetLowestScore(students));
    }

    [Fact]
    public void Average_WithNegativeScores()
    {
        var students = new List<Student>
        {
            new("A", -10),
            new("B", 10)
        };

        Assert.Equal(0, GradeCalculator.CalculateAverage(students));
    }

    [Fact]
    public void Grade_ExactlyBoundaryValues()
    {
        Assert.Equal("A", GradeCalculator.GetGrade(90));
        Assert.Equal("B", GradeCalculator.GetGrade(80));
        Assert.Equal("C", GradeCalculator.GetGrade(70));
        Assert.Equal("D", GradeCalculator.GetGrade(60));
    }

    [Fact]
    public void Grade_BelowAllBoundaries()
    {
        Assert.Equal("F", GradeCalculator.GetGrade(59.99));
    }

    [Fact]
    public void Grade_JustAboveBoundary()
    {
        Assert.Equal("A", GradeCalculator.GetGrade(90.01));
    }

    [Fact]
    public void Main_ZeroStudents_PrintsReport()
    {
        var oldIn = Console.In;
        var oldOut = Console.Out;

        try
        {
            Console.SetIn(new StringReader("0\n3\n"));
            using var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main();

            string output = writer.ToString();

            Assert.Contains("Student Grade Tracker", output);
            Assert.Contains("Grade Report", output);
        }
        finally
        {
            Console.SetIn(oldIn);
            Console.SetOut(oldOut);
        }
    }

    [Fact]
    public void Main_StudentInput_PrintsStudent()
    {
        var oldIn = Console.In;
        var oldOut = Console.Out;

        try
        {
            Console.SetIn(new StringReader("1\nAlice\n90\n3\n"));
            using var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main();

            string output = writer.ToString();

            Assert.Contains("Alice", output);
            Assert.Contains("90.00", output);
        }
        finally
        {
            Console.SetIn(oldIn);
            Console.SetOut(oldOut);
        }
    }

    [Fact]
    public void Main_SearchStudent_PrintsResult()
    {
        var oldIn = Console.In;
        var oldOut = Console.Out;

        try
        {
            Console.SetIn(new StringReader(
                "1\nAlice\n90\n1\nAlice\n3\n"));

            using var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main();

            Assert.Contains("Alice", writer.ToString());
        }
        finally
        {
            Console.SetIn(oldIn);
            Console.SetOut(oldOut);
        }
    }
}