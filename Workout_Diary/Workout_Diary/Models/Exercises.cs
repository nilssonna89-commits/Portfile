using MongoDB.Bson;

namespace Workout_Diary.Models
{
    public class Exercises // Övningar
    {
        public ObjectId Id { get ; set; }
        public string Description { get; set; }
        public string Name { get; set; }

    }
}
