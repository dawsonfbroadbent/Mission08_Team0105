using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0105.Models;
using System.Diagnostics;
using Task = Mission08_Team0105.Models.Task;

namespace Mission08_Team0105.Controllers;

public class HomeController : Controller
{
    private ITasksRepository _repo;
    public HomeController(ITasksRepository temp)
    {
        _repo = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddEditTask()
    {
        ViewBag.Categories = _repo.GetCategories();
        return View("AddEditTask", new Task());
    }

    public IActionResult quadrants()
    {
        var tasks = _repo.GetTasks()
            .OrderBy(x => x.Id).ToList();

        return View(tasks);
    }

    [HttpPost]
    public IActionResult AddEditTask(Task response)
    {
        if (ModelState.IsValid)
        {
            _repo.AddTask(response);

            return RedirectToAction("quadrants");
        }
        else
        {
            ViewBag.Categories = _repo.GetCategories();

            return View(response);
        }
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordtoEdit = _repo.GetTaskById(id);

        ViewBag.Categories = _repo.GetCategories();

        return View("AddEditTask", recordtoEdit);
    }

    [HttpPost]
    public IActionResult Edit(Task updatedInfo)
    {
        _repo.UpdateTask(updatedInfo);

        return RedirectToAction("quadrants");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordtoDelete = _repo.GetTaskById(id);

        return View(recordtoDelete);
    }

    [HttpPost]
    public IActionResult Delete(Task recordtoDelete)
    {
        _repo.DeleteTaskById(recordtoDelete.Id);
        return RedirectToAction("quadrants");
    }
}