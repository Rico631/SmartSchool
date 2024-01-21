using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Students.Data;

namespace SmartSchool.Students.Students.Display;

public record ListStudents(PagingOptions Paging) 
    : IRequest<IEnumerable<StudentBasicInfo>>;

public class ListStudentsHandler(AppDbContext context) : IRequestHandler<ListStudents, IEnumerable<StudentBasicInfo>>
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<StudentBasicInfo>> Handle(ListStudents request, CancellationToken cancellationToken)
    {
        var itemsToSkip = request.Paging.PageSize * (request.Paging.PageNumber - 1);

        var students = await _context.Students
            .OrderBy(x => x.Id)
            .Skip(itemsToSkip)
            .Take(request.Paging.PageSize)
            .Select(x => StudentBasicInfo.FromStudent(x))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return students;
    }
}
