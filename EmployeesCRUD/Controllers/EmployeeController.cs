using AutoMapper;
using EmployeesCRUD.DTOs;
using EmployeesCRUD.Mediatr.AddEmployee;
using EmployeesCRUD.Mediatr.DeleteEmployee;
using EmployeesCRUD.Mediatr.GetAllEmployees;
using EmployeesCRUD.Mediatr.GetEmployeesByDepartment;
using EmployeesCRUD.Mediatr.GetPaginatedEmployees;
using EmployeesCRUD.Mediatr.GetSalary;
using EmployeesCRUD.Mediatr.SetNewDepartment;
using EmployeesCRUD.Mediatr.SetNewJobTitle;
using EmployeesCRUD.Mediatr.UpdateEmployee;
using EmployeesCRUD.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesCRUD.Controllers;

[Route("[controller]/[action]")]
public class EmployeeController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EmployeeController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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
        var request = _mapper.Map<AddEmployeeRequest>(requestDto);

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
        return Ok(response.Value.Employees);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var request = new GetAllEmployeesRequest();
        var response = await _mediator.Send(request);
        return Ok(response.Value.Employees);
    }

    [HttpGet]
    public async Task<IActionResult> GetSalary(long id)
    {
        var request = new GetSalaryRequest(id);
        var response = await _mediator.Send(request);
        return Ok(response.Value.Salary);
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedEmployees(int currentPage, int pageSize)
    {
        var request = new GetPaginatedEmployeesRequest(currentPage, pageSize);
        var response = await _mediator.Send(request);
        return Ok(response.Value);
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

    [HttpPost]
    public async Task<IActionResult> SetNewDepartment(long employeeId, string departmentName)
    {
        var request = new SetNewDepartmentRequest(employeeId, departmentName);
        var response = await _mediator.Send(request);
        if (response.IsFailed)
        {
            return BadRequest(response.Stringify());
        }

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequestDto requestDto)
    {
        var request = _mapper.Map<UpdateEmployeeRequest>(requestDto);
        var response = await _mediator.Send(request);
        if (response.IsFailed)
        {
            return BadRequest(response.Stringify());
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee(long employeeId)
    {
        var request = new DeleteEmployeeRequest(employeeId);
        var response = await _mediator.Send(request);
        if (response.IsFailed)
        {
            return BadRequest(response.Stringify());
        }

        return Ok();
    }
}