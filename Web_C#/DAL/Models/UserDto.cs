using System.ComponentModel.DataAnnotations;

namespace Web_C_.Database.Data
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }

    }
}
