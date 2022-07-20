using Ispit19072022.Models.BindingModel;
using Ispit19072022.Models.Dbo;
using Ispit19072022.Models.ViewModel;
using Ispit19072022.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ispit19072022.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IToDoService toDoService;
        private readonly UserManager<AspNetUser> UserManager;

        public UserProfileController(IToDoService toDoService, UserManager<AspNetUser> userManager)
        {
            this.toDoService = toDoService;
            UserManager = userManager;
        }

        public async Task<IActionResult> Profile()
        {
            var todoLists = await toDoService.GetToDoList();
            return View(todoLists);
        }


        public async Task<IActionResult> CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDoList(ToDoListBinding model)
        {
            var userId = UserManager.GetUserId(User);
            model.AspNetUserId = userId;
            var todoLists = await toDoService.CreateToDoList(model);
            return RedirectToAction("Profile");
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ToDoListId = id;
            CreateTaskViewModel model = new CreateTaskViewModel();
            model.Tasks = await toDoService.GetTasks(id);
            model.ToLisId = id;
            return View(model);
        }

        public async Task<IActionResult> CreateTask(int id)
        {
            return View(new TaskBinding { ToDoListId = id });
        }

        public async Task<IActionResult> ChangeTaskStatus(int id, bool status)
        {
            var task = await toDoService.ChangeTaskStatus(id, status);
            return RedirectToAction("Details", new { id = task.ToDoList.Id });
        }


        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskBinding model)
        {
            var task = await toDoService.CreateTask(model);

            return RedirectToAction("Details", new { id = task.ToDoList.Id });
        }
    }
}
