using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.Students.Students.Manage;

[ApiController]
[Route("/students")]
public class ManageStudentsController : StudentsBaseController
{
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var command = new DeleteStudent(id);
        await Mediator.Send(command);

        return NoContent();
    }
}
