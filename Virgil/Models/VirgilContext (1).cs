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

        public IDbSet<TopicLink> Links { get; set; }
        public IDbSet<Medium> Media { get; set; }
        public IDbSet<Reference> References { get; set; }
        public IDbSet<Topic> Topics { get; set; }
        public IDbSet<Icon> Icons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TopicLinkMap());
            modelBuilder.Configurations.Add(new MediumMap());
            modelBuilder.Configurations.Add(new ReferenceMap());
            modelBuilder.Configurations.Add(new TopicMap());
            //modelBuilder.Configurations.Add(new IconMap());
        }
    }
}
