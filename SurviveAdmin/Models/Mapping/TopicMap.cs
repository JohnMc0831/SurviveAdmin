using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SurviveAdmin.Models.Mapping
{
    public class TopicMap : EntityTypeConfiguration<Topic>
    {
        public TopicMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Topics");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.Body).HasColumnName("Body");
        }
    }
}
