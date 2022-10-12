using Domain.Dtos;

namespace Infrastructure.Services;

public interface IDepartmentService
{
    Task<List<GetDepartmentDto>> GetDepartments();
    Task<UpdateDepartmentDto> GetDepartmentById(int id);
    Task<AddDepartmentDto> AddDepartment(AddDepartmentDto createDepartmentDto);
    Task<UpdateDepartmentDto> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto);
    Task<bool> DeleteDepartment(int id);
}