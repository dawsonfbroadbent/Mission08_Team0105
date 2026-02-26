using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0105.Models;
using System.Diagnostics;

namespace Mission08_Team0105.Controllers;

public class HomeController : Controller
{
    private TasksContext _context;
    public HomeController(TasksContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddEditTask()
    {
        ViewBag.Categories = _context.Categories
           .OrderBy(x => x.Name)
           .ToList();

        return View("AddEditTask", new Task());
    }

    public IActionResult quadrants()
    {
        var tasks = _context.Tasks
            .Include(x => x.Category)
            .OrderBy(x => x.Id).ToList();

        return View(tasks);
    }

    [HttpPost]
    public IActionResult AddEditTask(Task response)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(response); //Add record to database
            _context.SaveChanges();

            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Name)
                .ToList();

            return View(response);
        }
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordtoEdit = _context.Tasks
            .Single(x => x.Id == id);

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Name)
            .ToList();

        return View("AddEditTask", recordtoEdit);
    }

    [HttpPost]
    public IActionResult Edit(Task updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();

        return RedirectToAction("quadrants");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordtoDelete = _context.Tasks
            .Single(x => x.Id == id);

        return View(recordtoDelete);
    }

    [HttpPost]
    public IActionResult Delete(Task recordtoDelete)
    {
        _context.Tasks.Remove(recordtoDelete);
        _context.SaveChanges();
        return RedirectToAction("quadrants");
    }
}