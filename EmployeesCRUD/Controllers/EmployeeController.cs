using EmployeesCRUD.DTOs;
using EmployeesCRUD.Mediatr.AddEmployee;
using EmployeesCRUD.Mediatr.GetEmployeeByDepartment;
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
        return Ok(response.Id);
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeesByDepartment(string departmentName)
    {
        var request = new GetEmployeesByDepartmentRequest(departmentName);
        var response = await _mediator.Send(request);
        return Ok(response.Employees);
    }
}