using EmployeesCRUD.DTOs;
using EmployeesCRUD.Mediatr.AddEmployee;
using EmployeesCRUD.Mediatr.GetEmployeesByDepartment;
using EmployeesCRUD.Mediatr.SetNewJobTitle;
using EmployeesCRUD.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesCRUD.Controllers;

[Route("[controller]/[action]")]
public class EmployeeController : Controller
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequestDto requestDto)
    {
        // Swagger -> ДТО ->
        //               middleware ->
        //                  Ручка ->
        //                      Запрос (request) медиатора ->
        //                          Handler медиатора ->
        //                  Ручка ->
        //              middleware ->
        //           ДТО ->
        // Swagger 
        var request = new AddEmployeeRequest(requestDto.Name, requestDto.SecondName, requestDto.LastName,
            requestDto.DateOfBirth, requestDto.DateOfEmployment, requestDto.DepartmentName, requestDto.JobTitle);
        var response = await _mediator.Send(request);
        if (response.IsFailed)
        {
            return BadRequest(response.Stringify());
        }
        return Ok(response.Value.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeesByDepartment(string departmentName)
    {
        var request = new GetEmployeesByDepartmentRequest(departmentName);
        var response = await _mediator.Send(request);
        return Ok(response.Employees);
    }

    [HttpPost]
    public async Task<IActionResult> SetNewJobTitle(long employeeId, JobTitle.JobTitles jobTitle)
    {
        var request = new SetNewJobTitleRequest(employeeId, jobTitle);
        var response = await _mediator.Send(request);
        if (response.IsFailed)
        {
            return BadRequest(response.Stringify());
        }
        return Ok();
    }
}