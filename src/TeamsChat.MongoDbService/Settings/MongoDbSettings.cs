using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsChat.MongoDbService.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string LogsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
