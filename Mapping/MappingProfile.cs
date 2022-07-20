using AutoMapper;
using Ispit19072022.Models.BindingModel;
using Ispit19072022.Models.Dbo;
using Ispit19072022.Models.ViewModel;

namespace Ispit19072022.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AspNetUser, AspNetUserViewModel>();

            CreateMap<TaskBinding, Ispit19072022.Models.Dbo.Task>();
            CreateMap<Ispit19072022.Models.Dbo.Task, TaskViewModel>();

            CreateMap<ToDoListBinding, ToDoList>();
            CreateMap<ToDoList, ToDoListViewModel>();
        }
    }
}
