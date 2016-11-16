using System;

namespace Managers.Models
{
    public class UserWorkplaceModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public int WorkplaceId { get; set; }
        public WorkplaceModel Workplace { get; set; }

        public string Position { get; set; }

        public bool IsCurrentWorkplace { get; set; }

        public DateTime StartWorkDate { get; set; }

        public DateTime? EndWorkDate { get; set; }
    }
}
