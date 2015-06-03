using System;
using System.Collections.Generic;

namespace SurviveAdmin.Models
{
    public partial class Medium
    {
        public Medium()
        {
            this.Topics = new List<Topic>();
        }

        public int id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Tip { get; set; }
        public string MediaType { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
