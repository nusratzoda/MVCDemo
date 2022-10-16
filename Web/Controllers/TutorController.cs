using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class TutorController:Controller
{
      private readonly ITutorServices _tutorService;

    public TutorController(ITutorServices tutorService)
    {
        _tutorService = tutorService;
    }
    
    public async Task<IActionResult> Index()
    {
        //return list of tutors 
        var tutor = await _tutorService.GetTutor();
        return View(tutor);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        var emptyTutor = new AddTutorDto();
        return View(emptyTutor);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddTutorDto addTutorDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(addTutorDto);
        }
        await _tutorService.AddTutor(addTutorDto);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var tutor = await _tutorService.GetTutorById(id);
        return View(tutor);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateTutorDto updateTutorDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(updateTutorDto);
        }
        await _tutorService.UpdateTutor(updateTutorDto);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _tutorService.DeleteTutor(id);
        return RedirectToAction("Index");
    }
}
