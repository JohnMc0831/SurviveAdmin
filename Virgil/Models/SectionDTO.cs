using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Virgil.Models
{
    public class SectionDTO
    {
        public int id { get; set; }

        public int? EncounterId { get; set; }

        public string SectionName { get; set; }

        [StringLength(50)]
        public string SectionIcon { get; set; }

        public List<int> TopicIds { get; set; }

        public List<TopicDTO> Topics { get; set; }

        public SectionDTO(Section s)
        {
            id = s.id;
            EncounterId = s.EncounterId.HasValue ? s.EncounterId : 0;
            SectionName = s.SectionName;
            SectionIcon = s.SectionIcon;
            Topics = s.Topics.Select(t => new TopicDTO(t)).ToList();
        }

    }
}