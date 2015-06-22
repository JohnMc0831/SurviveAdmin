using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Virgil.Models
{
    public partial class Topic
    {
        public Topic()
        {
            this.Links = new List<TopicLink>();
            this.Media = new List<Medium>();
            this.References = new List<Reference>();
        }

        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        [AllowHtml]
        public string Body { get; set; }
        [Display(Name="Display Order")]
        public int DisplayOrder { get; set; }
        public virtual ICollection<TopicLink> Links { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}
