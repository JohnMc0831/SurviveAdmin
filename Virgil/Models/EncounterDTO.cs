using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Virgil.Models
{
    public class EncounterDTO
    {
        public int id { get; set; }

        public string EncounterName { get; set; }
        public IEnumerable<SectionDTO> Sections { get; set; }

        public EncounterDTO(Encounter e)
        {
            id = e.id;
            EncounterName = e.EncounterName;
            Sections = e.Sections.Select(s => new SectionDTO(s)).ToList();
        }
    }
}