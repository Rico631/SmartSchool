using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Students.Data;

namespace SmartSchool.Students.Students.Display;

public record GetStudentDetails(int Id) : IRequest<StudentDetails?>;

public class GteStudentDetailsHandler(AppDbContext context)
    : IRequestHandler<GetStudentDetails, StudentDetails?>
{
    public async Task<StudentDetails?> Handle(GetStudentDetails request, CancellationToken cancellationToken)
    {
        var student = await context.Students
            .Include(x => x.Address)
            .Include(x => x.Relatives)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        if (student is null)
            return null;
        return StudentDetails.FromStudent(student);
    }
}