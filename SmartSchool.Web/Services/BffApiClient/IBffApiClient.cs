using Refit;

namespace SmartSchool.Web.Services.BffApiClient;

public interface IBffApiClient
{
    [Post("/students")]
    Task<StudentBasicInfo> CreateStudentAsync([Body] NewStudent newStudent);
    
    [Get("/students")]
    Task<StudentBasicInfo[]> GetStudentsAsync([Query] PagingOptions paging);

    [Get("/students/{id}")]
    Task<StudentDetails> GetStudentDetailsAsync(int id);

    [Delete("/students/{studentId}")]
    Task DeleteStudentAsync(int studentId);
}
