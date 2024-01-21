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

        students.MapGet("/", GetStudents)
            .WithName(nameof(GetStudents))
            .Produces(200, typeof(IEnumerable<StudentBasicInfo>));


        return app;
    }

    private static async Task<IResult> CreateStudent(IStudentsApiClient client, NewStudent newStudent)
    {
        var result = await client.CreateStudent(newStudent);
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> GetStudents(IStudentsApiClient client, int pageNumber, int pageSize)
    {
        var result = await client.GetStudents(new PagingOptions(pageNumber, pageSize));
        return TypedResults.Ok(result);
    }
}
