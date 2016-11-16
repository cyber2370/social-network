using System;

namespace DbContext.Entities
{

    public class UserWorkplace
    {
        public UserWorkplace()
        {
        }

        public UserWorkplace(
            int userId,
            int workplaceId,
            string position,
            DateTime startWorkDate,
            DateTime? endWorkDate)
        {
            UserId = userId;
            WorkplaceId = workplaceId;
            Position = position;
            StartWorkDate = startWorkDate;
            EndWorkDate = endWorkDate;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int WorkplaceId { get; set; }

        public string Position { get; set; }

        public DateTime StartWorkDate { get; set; }

        public DateTime? EndWorkDate { get; set; }
    }
}
