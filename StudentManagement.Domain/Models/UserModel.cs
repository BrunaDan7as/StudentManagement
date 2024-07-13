using StudentManagement.Domain.Models.Base;

namespace StudentManagement.Domain.Models
{
    public class UserModel : BaseModel
    {

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
