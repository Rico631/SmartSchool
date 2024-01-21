using SmartSchool.Students.Domain.Models;

namespace SmartSchool.Students.Students;

public record StudentBasicInfo(
    int StudentId,
    string RollNumber,
    string FirstName,
    string LastName,
    string? Email,
    DateTime DateOfBirth,
    int Age)
{
    public static StudentBasicInfo FromStudent(Student student)
        => new(
            student.Id,
            student.RollNumber,
            student.FirstName,
            student.LastName,
            student.Email,
            student.DateOfBirth,
            student.Age);
}
