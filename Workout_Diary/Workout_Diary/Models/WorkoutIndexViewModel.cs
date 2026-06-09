using MongoDB.Bson;

namespace Workout_Diary.Models
{
    public class WorkoutIndexViewModel
    {
        public ObjectId Id { get; set; }
        public string ExerciseName { get; set; }
        public string WorkoutName { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string WorkoutDescription { get; set; }
        public int Repetitions { get; set; } = 0;
        public int Sets { get; set; } = 0;  
        public int Km { get; set; } = 0; 
    }
}
