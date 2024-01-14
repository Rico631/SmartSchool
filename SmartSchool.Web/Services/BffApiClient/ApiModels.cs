namespace SmartSchool.Web.Services.BffApiClient;

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
