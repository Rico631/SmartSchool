using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.Students.Students.Create;

public class CreateStudentController : StudentsBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(StudentBasicInfo), 200)]
    public async Task<IActionResult> CreateStudent([FromBody] NewStudent newStudent, CancellationToken token)
    {
        var command = new CreateStudent(newStudent);
        var result = await Mediator.Send(command, token);

        return Ok(result);
    }
}

public record NewStudent(
    string RollNumber,
    string FirstName,
    string LastName,
    DateTime DateOfBirth);
