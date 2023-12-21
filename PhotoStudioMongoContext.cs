using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio
{
    public class PhotoStudioMongoContext
    {
        string connectionString;
        MongoClient client;
        IMongoDatabase database;

        public IMongoCollection<Order> OrderCollection
        { get => database.GetCollection<Order>("Order"); }

        public IMongoCollection<Person> PersonCollection
        { get => database.GetCollection<Person>("Person"); }

        public IMongoCollection<Photographer> PhotographerCollection
        { get => database.GetCollection<Photographer>("Photographer"); }

        public IMongoCollection<User> UserCollection
        { get => database.GetCollection<User>("User"); }

        public PhotoStudioMongoContext(string cs)
        {
            connectionString = "mongodb://localhost:27017/PhotoStudioMongoDB";
            var connection = new MongoUrlBuilder(connectionString);
            client = new MongoClient(connectionString);
            database = client.GetDatabase(connection.DatabaseName);

            //if (ManufacturerCollection.CountDocuments(FilterDefinition<Manufacturer>.Empty) == 0) Seed();
        }
    }
}
