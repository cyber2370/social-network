using System.Data.Entity;
using DbContext.Entities;
using DbContext.Entities.AspNet;
using Microsoft.AspNet.Identity.EntityFramework;
    
namespace DbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = SocialNetworkDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";

        public AppDbContext() : base(ConnectionString)
        {

        }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Workplace> Workplaces { get; set; }

        public virtual DbSet<UserWorkplace> UsersWorkplaces { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<UserProfile>()
                .HasKey(x => x.UserId)
                .HasRequired(x => x.User)
                .WithRequiredDependent(x => x.Profile);

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

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
