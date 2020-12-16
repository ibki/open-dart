using MongoDB.Driver;
using OpenDart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDart.WebAPI.Services
{
    public class OpenDartMongoService
    {

        public OpenDartMongoService(IOpenDartDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            //client.ListDatabaseNames()

        }
    }
}
