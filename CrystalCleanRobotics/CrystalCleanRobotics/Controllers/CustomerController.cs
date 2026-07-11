using CrystalCleanRobotics.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrystalCleanRobotics.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("CrystalCleanRobotics");
            var collection = database.GetCollection<Customer>("Customers");
            collection.InsertOne(customer);
            return RedirectToAction("Index");
        }
        
        public IActionResult Show()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("CrystalCleanRobotics");
            var collection = database.GetCollection<Customer>("Customers");
            List<Customer> customer = collection.Find(new BsonDocument()).ToList();
            return View(customer);
        }
        public IActionResult Shows(string Id)
        {
            ObjectId customerId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("CrystalCleanRobotics");
            var collection = database.GetCollection<Customer>("Customers");
            Customer customer = collection.Find(c => c.Id == customerId).FirstOrDefault();
            return View(customer);


        }
        public IActionResult Delete(string Id)
        {
            ObjectId customerId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("CrystalCleanRobotics");
            var collection = database.GetCollection<Customer>("Customers");
            collection.DeleteOne(c => c.Id == customerId);
            return RedirectToAction("Show");
        }

    }
}
