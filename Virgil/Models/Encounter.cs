namespace Virgil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Encounter
    {
        public int id { get; set; }

        [Required]
        public string EncounterName { get; set; }
    }
}
