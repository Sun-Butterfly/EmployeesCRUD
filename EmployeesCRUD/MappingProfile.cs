using AutoMapper;
using EmployeesCRUD.DTOs;
using EmployeesCRUD.Mediatr.AddEmployee;
using EmployeesCRUD.Mediatr.UpdateEmployee;

namespace EmployeesCRUD;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddEmployeeRequestDto, AddEmployeeRequest>();
        CreateMap<UpdateEmployeeRequestDto, UpdateEmployeeRequest>();
    }
}