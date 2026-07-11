using MongoDB.Bson;

namespace CrystalCleanRobotics.Models
{
    public class Customer
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public int Phone { get; set; }
    }
}
