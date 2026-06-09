using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Workout_Diary.Models;

namespace Workout_Diary.Controllers
{
    public class WorkoutsController : Controller
    {
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("WorkoutDiary");
            var workoutsCollection = database.GetCollection<Workout>("Workouts");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");

            List<Workout> workouts = workoutsCollection.Find(w => true).ToList();

            List<WorkoutIndexViewModel> viewModel = new List<WorkoutIndexViewModel>();

            foreach (Workout workout in workouts)
            {
                
                if (!ObjectId.TryParse(workout.ExercisesId, out ObjectId exercisesId))
                {
                    
                    continue;
                }

                Exercises exercise = exercisesCollection.Find(e => e.Id == exercisesId).FirstOrDefault();

                WorkoutIndexViewModel model = new WorkoutIndexViewModel();
                model.Id = workout.Id;
                model.WorkoutName = workout.Name;
                model.WorkoutDate = workout.Date;
                model.Repetitions = workout.Repetitions;
                model.Sets = workout.Sets;
                model.Km = workout.Km;

                model.ExerciseName = exercise?.Name ?? "Okänt namn";
                model.WorkoutDescription = exercise?.Description ?? "Ingen beskrivning";

                viewModel.Add(model);
            }

            return View(viewModel);
        }
        public ActionResult Create()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("WorkoutDiary");
            var exercisesCollection = database.GetCollection<Exercises>("Exercises");

            List<Exercises> exercises = exercisesCollection.Find(e => true).ToList();

            return View(exercises); 
        }
        [HttpPost]
        public ActionResult Create(Workout workout)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("WorkoutDiary");
            
            var workoutsCollection = database.GetCollection<Workout>("Workouts");
            workoutsCollection.InsertOne(workout);

            return RedirectToAction("Index");

        }
        public ActionResult Delete(string id)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("WorkoutDiary");
            var workoutsCollection = database.GetCollection<Workout>("Workouts");
            workoutsCollection.DeleteOne(w => w.Id == new MongoDB.Bson.ObjectId(id));

            return RedirectToAction("Index");

        }

        public ActionResult Edit(string id)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("WorkoutDiary");
            var workoutsCollection = database.GetCollection<Workout>("Workouts");

            ObjectId objectId = new ObjectId(id);

            Workout workout = workoutsCollection.Find(w => w.Id == objectId).FirstOrDefault();

            if (workout == null)
                return NotFound();

            return View(workout);
        }
        [HttpPost]
        public ActionResult Edit(Workout workout)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("WorkoutDiary");
            var workoutsCollection = database.GetCollection<Workout>("Workouts");

            workoutsCollection.ReplaceOne(w => w.Id == workout.Id, workout);

            return RedirectToAction("Index");

        }
    }
}
