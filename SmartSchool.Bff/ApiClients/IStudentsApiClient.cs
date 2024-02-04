using Refit;

namespace SmartSchool.Bff.ApiClients;

public interface IStudentsApiClient
{
    [Post("/students")]
    Task<StudentBasicInfo> CreateStudent([Body] NewStudent newStudent);

    [Get("/students")]
    Task<StudentBasicInfo[]> ListStudents([Query] PagingOptions paging);

    [Get("/students/{id}")]
    Task<StudentDetails> GetStudentDetails(int id);

    [Delete("/students/{studentId}")]
    Task DeleteStudent(int studentId);
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

public record StudentDetails(
    int StudentId,
    string RollNumber,
    string FirstName,
    string LastName,
    string? Email,
    DateTime DateOfBirth,
    string? PhoneNumber,
    AddressDetails? AddressDetails,
    ICollection<StudentRelative> Relatives);

public record AddressDetails(
    string Street,
    int StreetNumber,
    string City,
    string State,
    string PostalCode,
    string Country);

public enum RelativeType
{
    Mother,
    Father,
    Brother,
    Sister
}

public record StudentRelative(
    bool IsGuardian,
    string FirstName,
    string LastName,
   RelativeType RelationshipToStudent);