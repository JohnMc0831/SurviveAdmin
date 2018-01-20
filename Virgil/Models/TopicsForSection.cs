using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Virgil.Models
{
    public class TopicsForSection
    {
        public int SectionId { get; set; }
        public List<string> Topics { get; set; }
    }

}