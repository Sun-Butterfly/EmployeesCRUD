using EmployeesCRUD.Mediatr.GetAllDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesCRUD.Controllers;

[Route("[controller]/[action]")]
public class DepartmentController : Controller
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDepartments()
    {
        var request = new GetAllDepartmentRequest();
        var response = await _mediator.Send(request);
        return Ok(response.Departments);
    }
}