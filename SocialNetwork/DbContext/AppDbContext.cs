using System.Data.Entity;
using DbContext.Entities;

namespace DbContext
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        private const string ConnectionString = 
             @"Data Source=(localdb)\MSSQLLocalDB;" 
            + "Initial Catalog=SocialNetworkDb;" 
            + "Integrated Security=True;"
            + "Connect Timeout=30;"
            + "Encrypt=False;"
            + "TrustServerCertificate=True;" 
            + "ApplicationIntent=ReadWrite;"
            + "MultiSubnetFailover=False";

        public AppDbContext() : base(ConnectionString)
        {

        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Workplace> Workplaces { get; set; }

        public virtual DbSet<UserWorkplace> UsersWorkplaces { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<FriendRequest> FriendRequests { get; set; }
    }
}
