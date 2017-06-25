using System.Data.Entity.ModelConfiguration;

namespace Virgil.Models.Mapping
{
    public class IconMap : EntityTypeConfiguration<Icon>
    {
        public IconMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.icon).IsRequired();

            // Table & Column Mappings
            this.ToTable("Topics");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.icon).HasColumnName("icon");
        }
    }
}