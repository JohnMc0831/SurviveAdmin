using System;
using System.Collections.Generic;

namespace Virgil.Models
{
    public partial class Reference
    {
        public Reference()
        {
            this.Topics = new List<Topic>();
        }

        public int id { get; set; }
        public string Reference1 { get; set; }
        public Nullable<int> LinkId { get; set; }
        public virtual Link Link { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
