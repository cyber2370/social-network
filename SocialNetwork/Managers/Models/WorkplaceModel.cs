namespace Managers.Models
{
    public class WorkplaceModel
    {
        public WorkplaceModel()
        {
        }

        public WorkplaceModel(
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
