using Domain.Dtos;

namespace Infrastructure.Services;

public interface ITutorServices
{
    Task<List<GetTutorDto>> GetTutor();
    Task<UpdateTutorDto> GetTutorById(int id);
    Task<AddTutorDto> AddTutor(AddTutorDto createTutorDto);
    Task<UpdateTutorDto> UpdateTutor(UpdateTutorDto updateTutorDto);
    Task<bool> DeleteTutor(int id);
}
