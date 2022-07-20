using Microsoft.AspNetCore.Identity;

namespace Ispit19072022.Models.Dbo
{
    public class AspNetUser: IdentityUser
    {
        public ICollection<ToDoList> ToDoList { get; set; }
    }
}
