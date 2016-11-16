namespace Managers.Models
{
    public class LocationModel
    {
        public LocationModel()
        {
        }

        public LocationModel(
            string country,
            string city,
            string street)
        {
            Country = country;
            City = city; ;
            Street = street;
        }

        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
