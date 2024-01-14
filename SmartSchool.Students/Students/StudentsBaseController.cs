using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.Students.Students;

[ApiController]
[Route("/students")]
public class StudentsBaseController : ControllerBase
{
    protected IMediator Mediator =>
        HttpContext.RequestServices.GetRequiredService<IMediator>();
}
