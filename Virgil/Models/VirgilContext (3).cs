namespace Virgil.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VirgilContext : DbContext
    {
        public VirgilContext()
            : base("name=VirgilModel")
        {
        }

        public virtual DbSet<Encounter> Encounters { get; set; }
        public virtual DbSet<Icon> Icons { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>()
                .HasMany(e => e.Topics)
                .WithMany(e => e.Links)
                .Map(m => m.ToTable("TopicsLinks").MapLeftKey("LinkId").MapRightKey("TopicId"));

            modelBuilder.Entity<Medium>()
                .HasMany(e => e.Topics)
                .WithMany(e => e.Media)
                .Map(m => m.ToTable("TopicsMedia").MapLeftKey("MediaId").MapRightKey("TopicId"));

            modelBuilder.Entity<Reference>()
                .HasMany(e => e.Topics)
                .WithMany(e => e.References)
                .Map(m => m.ToTable("TopicsReferences").MapLeftKey("ReferenceId").MapRightKey("TopicId"));

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Topics)
                .WithMany(e => e.Sections)
                .Map(m => m.ToTable("SectionsXTopics").MapLeftKey("SectionId").MapRightKey("TopicId"));
        }
    }
}
