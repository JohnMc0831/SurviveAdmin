using System;
using System.Collections.Generic;

namespace SurviveAdmin.Models
{
    public partial class Topic
    {
        public Topic()
        {
            this.Links = new List<Link>();
            this.Media = new List<Medium>();
            this.References = new List<Reference>();
        }

        public int id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}
