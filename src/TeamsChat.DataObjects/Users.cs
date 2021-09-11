namespace TeamsChat.DataObjects
{
    public class Users : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UsersCredentials UsersCredentials { get; set; }
    }
}
