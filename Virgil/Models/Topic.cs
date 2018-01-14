namespace Virgil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            Sections = new HashSet<Section>();
            Links = new HashSet<Link>();
            Media = new HashSet<Medium>();
            References = new HashSet<Reference>();
        }

        public int id { get; set; }

        [Required]
        public string Title { get; set; }

        public string TitleGerman { get; set; }

        public string TitleSpanish { get; set; }

        public string Summary { get; set; }

        public string SummaryGerman { get; set; }

        public string SummarySpanish { get; set; }

        public string Body { get; set; }

        public string BodyGerman { get; set; }

        public string BodySpanish { get; set; }

        public string BackColor { get; set; }

        public string TextColor { get; set; }

        public int DisplayOrder { get; set; }

        [StringLength(100)]
        public string TopicIcon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Section> Sections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Link> Links { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reference> References { get; set; }
    }
}
