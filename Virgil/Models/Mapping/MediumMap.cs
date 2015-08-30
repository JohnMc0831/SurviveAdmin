using System.Data.Entity.ModelConfiguration;

namespace Virgil.Models.Mapping
{
    public class MediumMap : EntityTypeConfiguration<Medium>
    {
        public MediumMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.FileName)
                .IsRequired();

            this.Property(t => t.ContentType)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Media");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.Tip).HasColumnName("Tip");
            this.Property(t => t.ContentType).HasColumnName("ContentType");

            // Relationships
            this.HasMany(t => t.Topics)
                .WithMany(t => t.Media)
                .Map(m =>
                    {
                        m.ToTable("TopicsMedia");
                        m.MapLeftKey("MediaId");
                        m.MapRightKey("TopicId");
                    });


        }
    }
}
