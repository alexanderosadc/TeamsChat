namespace TeamsChat.DataObjects
{
    public class UserMessageGroups
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public int MessageGroupsId { get; set; }
        public MessageGroups MessageGroups { get; set; }
    }
}
