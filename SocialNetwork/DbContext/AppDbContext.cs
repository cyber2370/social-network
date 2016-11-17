using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DbContext.Entities;

namespace DbContext
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = SocialNetworkDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";

        public AppDbContext() : base(ConnectionString)
        {

        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Workplace> Workplaces { get; set; }

        public virtual DbSet<UserWorkplace> UsersWorkplaces { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<FriendRequest>()
                .HasRequired(p => p.Requester)
                .WithMany(x => x.OutgoingFriendRequests)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<FriendRequest>()
                .HasRequired(p => p.Confirmer)
                .WithMany(x => x.IncomingFriendRequests)
                .WillCascadeOnDelete(false);
        }
    }
}
