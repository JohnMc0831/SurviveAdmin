using System;
using System.Collections.Generic;

namespace SurviveAdmin.Models
{
    public partial class Link
    {
        public Link()
        {
            this.References = new List<Reference>();
            this.Topics = new List<Topic>();
        }

        public int id { get; set; }
        public string Title { get; set; }
        public string Link1 { get; set; }
        public virtual ICollection<Reference> References { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
