namespace DbContext.Entities
{
    public class Workplace
    {
        public Workplace()
        {
        }

        public Workplace(
            string title,
            string description)
        {
            Title = title;
            Description = description;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
