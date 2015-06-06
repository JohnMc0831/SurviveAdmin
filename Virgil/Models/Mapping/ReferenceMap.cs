using System.Data.Entity.ModelConfiguration;

namespace Virgil.Models.Mapping
{
    public class ReferenceMap : EntityTypeConfiguration<Reference>
    {
        public ReferenceMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Reference1)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("References");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Reference1).HasColumnName("Reference");
            this.Property(t => t.LinkId).HasColumnName("LinkId");

            // Relationships
            this.HasMany(t => t.Topics)
                .WithMany(t => t.References)
                .Map(m =>
                    {
                        m.ToTable("TopicsReferences");
                        m.MapLeftKey("ReferenceId");
                        m.MapRightKey("TopicId");
                    });

            this.HasOptional(t => t.Link)
                .WithMany(t => t.References)
                .HasForeignKey(d => d.LinkId);

        }
    }
}
