using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentService : IDepartmentService
{
    private readonly DataContext _context;

    public DepartmentService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetDepartmentDto>> GetDepartments()
    {
        var departments = await _context.Departments
            .Select(d => new GetDepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            })
            .ToListAsync();
        
        return departments;
    }
    
    public async Task<UpdateDepartmentDto> GetDepartmentById(int id)
    {
        var department = await _context.Departments
            .Select(d => new UpdateDepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            })
            .FirstOrDefaultAsync(d => d.Id == id);
        
        return department;
    }
    
    public async Task<AddDepartmentDto> AddDepartment(AddDepartmentDto createDepartmentDto)
    {
        var department = new Department
        {
            Name = createDepartmentDto.Name,
            Description = createDepartmentDto.Description
        };
        
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        
        createDepartmentDto.Id = department.Id;
        return createDepartmentDto;
    }
    
    public async Task<UpdateDepartmentDto> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == updateDepartmentDto.Id);
        
        if (department == null)
        {
            return null;
        }
        
        department.Name = updateDepartmentDto.Name;
        department.Description = updateDepartmentDto.Description;
        
        await _context.SaveChangesAsync();
        
        return updateDepartmentDto;
    }
    
    public async Task<bool> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        
        if (department == null)
        {
            return false;
        }
        
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        
        return true;
    }
}