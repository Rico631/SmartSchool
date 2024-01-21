using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.Students.Students.Display;

public class StudentInfoController : StudentsBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(StudentBasicInfo[]), 200)]
    public async Task<IActionResult> GetStudentInfo([FromQuery] PagingOptions paging, CancellationToken token)
    {
        var result = await Mediator.Send(new ListStudents(paging), token);

        return Ok(result);
    }
}

public record PagingOptions(int PageNumber = 1, int PageSize = 10);