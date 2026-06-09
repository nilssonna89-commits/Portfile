using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Workout_Diary.Models
{
    [BsonIgnoreExtraElements]
    public class Workout // Träningstillfälle
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string ExercisesId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Repetitions { get; set; } = 0;
        public int Sets { get; set; } = 0;
        public int Km { get; set; } = 0;
    }
}
