namespace Web_C_.ModelsView
{
    public class UserViewModel
    {
        public UserViewModel( string name, string email, string phone)
        {
            
            Name = name;
            Email = email;
            Phone = phone;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
