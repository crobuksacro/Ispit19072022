using Ispit19072022.Models.Base;

namespace Ispit19072022.Models.ViewModel
{
    public class TaskViewModel: TaskBase
    {
        public int Id { get; set; }
        public ToDoListViewModel ToDoList { get; set; }
    }
}
