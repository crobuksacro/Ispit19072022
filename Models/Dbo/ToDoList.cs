using Ispit19072022.Models.Base;
using Ispit19072022.Models.Dbo.Base;
using System.ComponentModel.DataAnnotations;

namespace Ispit19072022.Models.Dbo
{
    public class ToDoList : ToDoListBase, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Task> Task { get; set; }
        public AspNetUser AspNetUser { get; set; }
    }
}
