using MediatR;
using SmartSchool.Students.Data;

namespace SmartSchool.Students.Students.Manage;

public record DeleteStudent(int StudentId) : IRequest;


public class DeleteStudentHandler(AppDbContext context) : IRequestHandler<DeleteStudent>
{
    public async Task Handle(DeleteStudent request, CancellationToken cancellationToken)
    {
        var student = await context.Students.FindAsync(request.StudentId);
        if (student is null)
            return;

        context.Students.Remove(student);
        await context.SaveChangesAsync(cancellationToken);

    }
}