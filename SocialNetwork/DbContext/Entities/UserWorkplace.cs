using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bool isCurrentWorkplace,
            string position,
            DateTime startWorkDate,
            DateTime endWorkDate)
        {
            UserId = userId;
            WorkplaceId = workplaceId;
            IsCurrentWorkplace = isCurrentWorkplace;
            Position = position;
            StartWorkDate = startWorkDate;
            EndWorkDate = endWorkDate;
        }

        public int UserId { get; set; }

        public int WorkplaceId { get; set; }

        public bool IsCurrentWorkplace { get; set; }

        public string Position { get; set; }

        public DateTime StartWorkDate { get; set; }

        public DateTime? EndWorkDate { get; set; }
    }
}
