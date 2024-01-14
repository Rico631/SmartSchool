using SmartSchool.Bff.ApiClients;

namespace SmartSchool.Bff.Students;

public static class StudentEndpoints
{
    public static IEndpointRouteBuilder AddStudentEndpoints(this IEndpointRouteBuilder app)
    {
        var students = app.MapGroup("/students");

        students.MapPost("/", CreateStudent)
            .WithName("CreateStudent")
            .Produces(200, typeof(StudentBasicInfo));

        return app;
    }

    private static async Task<IResult> CreateStudent(IStudentsApiClient client, NewStudent newStudent)
    {
        var result = await client.CreateStudent(newStudent);
        return TypedResults.Ok(result);
    }
}
