namespace crud_system.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public bool Enable { get; set; }
        public Type type {  get; set; }

    }
}
