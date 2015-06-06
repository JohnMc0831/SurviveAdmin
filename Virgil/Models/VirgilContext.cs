using System.Data.Entity;
using Virgil.Models;
using Virgil.Models.Mapping;

namespace Virgil.Models
{
    public partial class VirgilContext : DbContext
    {
        static VirgilContext()
        {
            Database.SetInitializer<VirgilContext>(null);
        }

        public VirgilContext()
            : base("Name=VirgilContext")
        {
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Medium> Media { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LinkMap());
            modelBuilder.Configurations.Add(new MediumMap());
            modelBuilder.Configurations.Add(new ReferenceMap());
            modelBuilder.Configurations.Add(new TopicMap());
        }
    }
}
