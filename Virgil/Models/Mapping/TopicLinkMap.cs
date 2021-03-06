using System.Data.Entity.ModelConfiguration;

namespace Virgil.Models.Mapping
{
    public class TopicLinkMap : EntityTypeConfiguration<TopicLink>
    {
        public TopicLinkMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Link1)
                .IsRequired()
                .HasMaxLength(1024);

            // Table & Column Mappings
            this.ToTable("Links");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Link1).HasColumnName("Link");

            // Relationships
            this.HasMany(t => t.Topics)
                .WithMany(t => t.Links)
                .Map(m =>
                    {
                        m.ToTable("TopicsLinks");
                        m.MapLeftKey("LinkId");
                        m.MapRightKey("TopicId");
                    });


        }
    }
}
