using System.Collections.Generic;

namespace Virgil.Models
{
    public partial class TopicLink
    {
        public TopicLink()
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
