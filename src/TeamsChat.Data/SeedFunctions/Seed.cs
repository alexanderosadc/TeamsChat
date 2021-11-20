using System;
using System.Collections.Generic;
using System.Linq;
using TeamsChat.DataObjects.SSMSModels;

namespace TeamsChat.SSMS.SeedFunctions
{
    public class Seed
    {
        private SSMSContext _context;
        public Seed(SSMSContext context)
        {
            _context = context;
        }
        public void DevelopmentSeed()
        {
            if (_context.AttachedFiles.Any())
                return;

            var user1 = CreateUser(_context, "Maxim", "Volosenco", "maximvolosenco@gmail.com", "pass1");
            var user2 = CreateUser(_context, "Alex", "Osa", "osa@klock.com", "pass2");
            var user3 = CreateUser(_context, "Vova", "Leadavschi", "vova.leadavschi@gmail.com", "pass3");

            _context.SaveChanges();

            var messageGroup1 = CreateMessageGroup(_context, "FAF ONG", new List<User> { user1, user2});
            var messageGroup2 = CreateMessageGroup(_context, "PAD", new List<User> { user3, user2 });

            _context.SaveChanges();

            var message1 = CreateMessage(_context, "Gentlemen, you can’t fight in here. This is the war room.", user1, messageGroup1);
            var message2 = CreateMessage(_context, "My mother always used to say: The older you get, the better you get, unless you’re a banana.", user2, messageGroup1);
            var message3 = CreateMessage(_context, "Clothes make the man. Naked people have little or no influence in society.", user2, messageGroup1);
            var message4 = CreateMessage(_context, "Before you marry a person, you should first make them use a computer with slow Internet to see who they really are.", user2, messageGroup1);
            var message5 = CreateMessage(_context, "Ned, I would love to stand here and talk with you—but I’m not going to.", user2, messageGroup2);
            var message6 = CreateMessage(_context, "“I’m not superstitious, but I am a little stitious.", user3, messageGroup2);

            _context.SaveChanges();

            var attachedFile = CreateAttachedFile(_context, "breaj", "txt", "deleted", message1);

            _context.SaveChanges();
        }

        private static User CreateUser(
            SSMSContext context,
            string firstName,
            string lastName,
            string email,
            string password
            )
        {
            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            context.Users.Add(user);
            return user;
        }

        private static Message CreateMessage(
            SSMSContext context,
            string text,
            User user,
            MessageGroup messageGroup
            )
        {
            Message message = new Message
            {
                Text = text,
                CreatedAt = DateTime.Now,
                MessageGroup = messageGroup,
                User = user
            };
            context.Messages.Add(message);
            return message;           
        }

        private static MessageGroup CreateMessageGroup(
            SSMSContext context,
            string title,
            List<User> users
            )
        {
            MessageGroup messageGroup = new MessageGroup
            {
                Title = title,
                Users = users
            };
            context.MessageGroups.Add(messageGroup);
            return messageGroup;
        }

        private static AttachedFile CreateAttachedFile(
            SSMSContext context,
            string fileName,
            string mimeType,
            string fileFormat,
            Message message
            )
        {
            AttachedFile attachedFile = new AttachedFile
            {
                FileName = fileName,
                MimeType = mimeType,
                FileFormat = fileFormat,
                Message = message
            };
            context.AttachedFiles.Add(attachedFile);
            return attachedFile;
    }
    }
}
