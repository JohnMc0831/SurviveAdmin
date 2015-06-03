using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveAdmin.Models.Mapping
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

            this.Property(t => t.FilePath)
                .IsRequired();

            this.Property(t => t.MediaType)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Media");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
            this.Property(t => t.Tip).HasColumnName("Tip");
            this.Property(t => t.MediaType).HasColumnName("MediaType");

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
