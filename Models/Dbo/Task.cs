using Ispit19072022.Models.Base;
using Ispit19072022.Models.Dbo.Base;
using System.ComponentModel.DataAnnotations;

namespace Ispit19072022.Models.Dbo
{
    public class Task : TaskBase, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public ToDoList ToDoList { get; set; }
    }


}
