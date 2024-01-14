using Refit;

namespace SmartSchool.Bff.ApiClients;

public interface IStudentsApiClient
{
    [Post("/students")]
    Task<StudentBasicInfo> CreateStudent([Body] NewStudent newStudent);
}

public record NewStudent(
    string RollNumber,
    string FirstName,
    string LastName,
    DateTime DateOfBirth);

public record StudentBasicInfo(
    int StudentId,
    string RollNumber,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    int Age);
