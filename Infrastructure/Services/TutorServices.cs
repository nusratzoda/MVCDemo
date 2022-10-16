using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TutorServices : ITutorServices
{
    private readonly DataContext _context;

    public TutorServices(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTutorDto>> GetTutor()
    {
        var tutor = await _context.Tutors
            .Select(t => new GetTutorDto
            {
                Id = t.Id,
                FullName = t.FullName,
                Image = t.Image,
                Position = t.Position,
                BackgroundImage = t.BackgroundImage,
                Experience = t.Experience
            }).ToListAsync();

        return tutor;
    }

    public async Task<UpdateTutorDto> GetTutorById(int id)
    {
        var tutor = await _context.Tutors
            .Select(t => new UpdateTutorDto
            {
                Id = t.Id,
                FullName = t.FullName,
                Image = t.Image,
                Position = t.Position,
                BackgroundImage = t.BackgroundImage,
                Experience = t.Experience
            }).FirstOrDefaultAsync(t => t.Id == id);

        return tutor;
    }

    public async Task<AddTutorDto> AddTutor(AddTutorDto createTutorDto)
    {
        var tutor = new Tutor
        {
            Id = createTutorDto.Id,
            FullName = createTutorDto.FullName,
            Image = createTutorDto.Image,
            Position = createTutorDto.Position,
            BackgroundImage = createTutorDto.BackgroundImage,
            Experience = createTutorDto.Experience
        };

        await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();
        createTutorDto.Id = tutor.Id;
        return createTutorDto;
    }

    public async Task<UpdateTutorDto> UpdateTutor(UpdateTutorDto updateTutorDto)
    {
        var tutor = await _context.Tutors.FirstOrDefaultAsync(t => t.Id == updateTutorDto.Id);

        if (tutor == null)
        {
            return null;
        }
        tutor.Id = updateTutorDto.Id;
            tutor.FullName = updateTutorDto.FullName;
            tutor.Image = updateTutorDto.Image;
            tutor.Position = updateTutorDto.Position;
            tutor.BackgroundImage = updateTutorDto.BackgroundImage;
            tutor.Experience = updateTutorDto.Experience;

        await _context.SaveChangesAsync();

        return updateTutorDto;
    }

    public async Task<bool> DeleteTutor(int id)
    {
        var tutor = await _context.Tutors.FirstOrDefaultAsync(d => d.Id == id);

        if (tutor == null)
        {
            return false;
        }
        _context.Tutors.Remove(tutor);
        await _context.SaveChangesAsync();
        return true;
    }
}
