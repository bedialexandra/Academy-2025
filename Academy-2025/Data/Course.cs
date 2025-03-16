namespace Academy_2025.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Author { get; set; }

        public ICollection<User> Users { get; set; } = [];

    }
}
