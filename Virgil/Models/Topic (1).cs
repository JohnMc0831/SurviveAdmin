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
        [Display(Name = "Titel")]
        public string TitleGerman { get; set; }
        [Display(Name = "Título")]
        public string TitleSpanish { get; set; }
        public string Summary { get; set; }
        [Display(Name = "Zusammenfassung")]
        public string SummaryGerman { get; set; }
        [Display(Name = "Sumario")]
        public string SummarySpanish { get; set; }
        [Required]
        [AllowHtml]
        public string Body { get; set; }
        [AllowHtml]
        [Display(Name = "Hauptteil")]
        public string BodyGerman { get; set; }
        [AllowHtml]
        [Display(Name = "Cuerpo de Texto")]
        public string BodySpanish { get; set; }
        public string BackColor { get; set; }
        public string TextColor { get; set; }
        [Display(Name="Display Order")]
        public int DisplayOrder { get; set; }
        [Display(Name = "Icon")]
        public string TopicIcon { get; set; }
        public virtual ICollection<TopicLink> Links { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}
