using Refit;

namespace SmartSchool.Bff.ApiClients;

public interface IStudentsApiClient
{
    [Post("/students")]
    Task<StudentBasicInfo> CreateStudent([Body] NewStudent newStudent);

    [Get("/students")]
    Task<StudentBasicInfo[]> GetStudents([Query] PagingOptions paging);
}

public record NewStudent(
    string RollNumber,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth);

public record StudentBasicInfo(
    int StudentId,
    string RollNumber,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth,
    int Age);

public record PagingOptions(int PageNumber = 1, int PageSize = 10);