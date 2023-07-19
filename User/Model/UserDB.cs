using System.ComponentModel.DataAnnotations;

namespace Users.Model
{
    public class UserDB
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
