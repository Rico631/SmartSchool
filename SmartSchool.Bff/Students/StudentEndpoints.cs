using Microsoft.AspNetCore.Mvc;
using SmartSchool.Bff.ApiClients;

namespace SmartSchool.Bff.Students;

public static class StudentEndpoints
{
    public static IEndpointRouteBuilder AddStudentEndpoints(this IEndpointRouteBuilder app)
    {
        var students = app.MapGroup("/students");

        students.MapPost("/", CreateStudent)
            .WithName(nameof(CreateStudent))
            .Produces(200, typeof(StudentBasicInfo));

        students.MapGet("/", ListStudents)
            .WithName(nameof(ListStudents))
            .Produces(200, typeof(IEnumerable<StudentBasicInfo>));
        
        students.MapGet("/{studentId}", GetStudentDetails)
            .WithName(nameof(GetStudentDetails))
            .Produces(200, typeof(StudentDetails));

        students.MapDelete("/{studentId}", DeleteStudent)
            .WithName(nameof(DeleteStudent))
            .Produces(204);

        return app;
    }

    private static async Task<IResult> CreateStudent(IStudentsApiClient client, NewStudent newStudent)
    {
        var result = await client.CreateStudent(newStudent);
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> ListStudents(IStudentsApiClient client, int pageNumber, int pageSize)
    {
        var result = await client.ListStudents(new PagingOptions(pageNumber, pageSize));
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> GetStudentDetails(IStudentsApiClient client, int studentId)
    {
        var result = await client.GetStudentDetails(studentId);
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> DeleteStudent(IStudentsApiClient client, int studentId)
    {
        await client.DeleteStudent(studentId);
        return TypedResults.NoContent();
    }
}
