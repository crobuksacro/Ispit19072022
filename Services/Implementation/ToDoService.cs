using AutoMapper;
using Ispit19072022.Data;
using Ispit19072022.Models.BindingModel;
using Ispit19072022.Models.Dbo;
using Ispit19072022.Models.ViewModel;
using Ispit19072022.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ispit19072022.Services.Implementation
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ToDoService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

      
       
        /// <summary>
        /// Dodaj todolist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ToDoListViewModel?> CreateToDoList(ToDoListBinding model)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Id == model.AspNetUserId);
            if (user == null)
            {
                return null;
            }
            var dbo = mapper.Map<ToDoList>(model);
            dbo.AspNetUser = user;
            db.ToDoList.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ToDoListViewModel>(dbo);
        }

        /// <summary>
        /// Dohvati listu
        /// </summary>
        /// <returns></returns>
        public async Task<List<ToDoListViewModel>> GetToDoList()
        {
            var todoList = await db.ToDoList.ToListAsync();
            return todoList.Select(x => mapper.Map<ToDoListViewModel>(x)).ToList();

        }

        /// <summary>
        /// Izradi task
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<TaskViewModel?> CreateTask(TaskBinding model)
        {
            var toDoList = await db.ToDoList.FindAsync(model.ToDoListId);
            if (toDoList == null)
            {
                return null;
            }
            var dbo = mapper.Map<Models.Dbo.Task>(model);
            dbo.ToDoList = toDoList;
            db.Task.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<TaskViewModel>(dbo);
        }

        /// <summary>
        /// Promjena statusa taska
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<TaskViewModel?> ChangeTaskStatus(int taskId, bool status)
        {
            var task = await db.Task
                .Include(x=>x.ToDoList)
                .FirstOrDefaultAsync(x => x.Id == taskId);
            if (task == null)
            {
                return null;
            }

            task.Status = status;
            await db.SaveChangesAsync();
            return mapper.Map<TaskViewModel>(task);
        }
        /// <summary>
        /// Dohvati task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<TaskViewModel?> GetTask(int taskId)
        {
            var task = await db.Task.FirstOrDefaultAsync(x => x.Id == taskId);
            if (task == null)
            {
                return null;
            }
            return mapper.Map<TaskViewModel>(task);
        }



        /// <summary>
        /// Dohvati listu
        /// </summary>
        /// <param name="todoListId"></param>
        /// <returns></returns>
        public async Task<List<TaskViewModel>> GetTasks(int todoListId)
        {
            var task = await db.Task
                .Include(x=>x.ToDoList)
                .Where(x => x.ToDoList.Id == todoListId && !x.Status).ToListAsync();
            if (task == null)
            {
                return new List<TaskViewModel>();
            }

            return task.Select(x => mapper.Map<TaskViewModel>(x)).ToList();
        }

    }
}
