using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Workout_Diary.Models;

namespace Workout_Diary.Controllers
{
    public class ExercisesController : Controller
    {
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("WorkoutDiary");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");
            List<Exercises> exercises = exercisesCollection.Find(e => true).ToList();

            return View(exercises);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Exercises exercises)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("WorkoutDiary");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");
            exercisesCollection.InsertOne(exercises);
            return RedirectToAction("Index");
        }
        public IActionResult Show(string Id)
        {
            ObjectId ExercisesId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("WorkoutDiary");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");
            Exercises exercises = exercisesCollection.Find(e => e.Id == ExercisesId).FirstOrDefault();

            return View(exercises); 
        
        
        }

        public IActionResult Edit(string Id)
        {
            ObjectId ExercisesId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("WorkoutDiary");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");
            Exercises exercises = exercisesCollection.Find(e => e.Id == ExercisesId).FirstOrDefault();

            return View(exercises);
        }
        [HttpPost]
        public IActionResult Edit(Exercises exercises)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("WorkoutDiary");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");
            exercisesCollection.ReplaceOne(e => e.Id == exercises.Id, exercises);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string Id)
        {
            ObjectId ExercisesId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("WorkoutDiary");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");
            exercisesCollection.DeleteOne(e => e.Id == ExercisesId);
            return RedirectToAction("Index");
        }


    }
}
