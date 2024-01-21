namespace SmartSchool.Web.Services.BffApiClient;

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
    string? Email,
    DateTime DateOfBirth,
    int Age);

public record PagingOptions(int PageNumber = 1, int PageSize = 10);