using Ispit19072022.Models.BindingModel;
using Ispit19072022.Models.ViewModel;

namespace Ispit19072022.Services.Interface
{
    public interface IToDoService
    {
        Task<TaskViewModel?> ChangeTaskStatus(int taskId, bool status);
        Task<TaskViewModel?> CreateTask(TaskBinding model);
        Task<ToDoListViewModel?> CreateToDoList(ToDoListBinding model);
        Task<TaskViewModel?> GetTask(int taskId);
        Task<List<TaskViewModel>> GetTasks(int todoListId);
        Task<List<ToDoListViewModel>> GetToDoList();
    }
}