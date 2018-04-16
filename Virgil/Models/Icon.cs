namespace Virgil.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Icon
    {
        public int id { get; set; }

        [Column("icon")]
        [Required]
        [StringLength(100)]
        public string icon { get; set; }
    }
}
