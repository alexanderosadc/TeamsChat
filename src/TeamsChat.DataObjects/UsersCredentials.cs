namespace TeamsChat.DataObjects
{ 
    public class UsersCredentials : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
