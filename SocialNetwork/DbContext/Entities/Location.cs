namespace DbContext.Entities
{
    public class Location
    {
        public Location()
        {
        }

        public Location(
            string country,
            string city,
            string street)
        {
            Country = country;
            City = city;
            Street = street;
        }

        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
