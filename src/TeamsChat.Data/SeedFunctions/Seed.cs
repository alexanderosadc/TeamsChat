using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsChat.DataObjects;

namespace TeamsChat.Data.SeedFunctions
{
    public class Seed
    {
        private TeamsChatContext _context;
        public Seed(TeamsChatContext context)
        {
            _context = context;
        }
        public void PopulateWithData()
        {
            _context.Users.Add(new Users {FirstName = "Alex", LastName = "Osa", Email = "osa@klock.com", Password = "as"});
            _context.Users.Add(new Users { FirstName = "Vova", LastName = "Leadavshci", Email = "vova@ianepiu.com", Password = "12" });
            _context.Users.Add(new Users { FirstName = "Max", LastName = "Volosenco", Email = "mav@nehojuvuniver.com", Password = "12" });

            _context.SaveChanges();

            _context.MessageGroups.Add(new MessageGroups {Title = "Tusovka"});
            _context.MessageGroups.Add(new MessageGroups { Title = "Leadavschi Vova" });
            _context.MessageGroups.Add(new MessageGroups { Title = "Maxim Volosenco" });

            _context.Messages.Add(new Messages {Text = "Hello!", CreatedAt = DateTime.Now, MessageGroupsId = 1, UsersId = 1});
            _context.Messages.Add(new Messages { Text = "Goodbuy!", CreatedAt = DateTime.Now, MessageGroupsId = 1, UsersId = 2 });
            _context.Messages.Add(new Messages { Text = "Bratan", CreatedAt = DateTime.Now, MessageGroupsId = 2, UsersId = 2 });
            _context.Messages.Add(new Messages { Text = "Teza", CreatedAt = DateTime.Now, MessageGroupsId = 2, UsersId = 3 });
            _context.Messages.Add(new Messages { Text = "Leva", CreatedAt = DateTime.Now, MessageGroupsId = 3, UsersId = 1});
            _context.Messages.Add(new Messages { Text = "Bravo", CreatedAt = DateTime.Now, MessageGroupsId = 3, UsersId = 3});

            _context.AttachedFiles.Add(new AttachedFiles
                    { FileName = "breaj", MimeType = "txt", FileFormat = "deleted", MessagesId = 1 });
            _context.SaveChanges();
        }
    }
}
