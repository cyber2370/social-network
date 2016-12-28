using System;

namespace DbContext.Entities
{

    public class UserWorkplace
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int WorkplaceId { get; set; }

        public string Position { get; set; }

        public DateTime StartWorkDate { get; set; }

        public DateTime? EndWorkDate { get; set; }
    }
}
