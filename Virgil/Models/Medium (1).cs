using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Virgil.Models
{
    public partial class Medium
    {
        public Medium()
        {
            this.Topics = new List<Topic>();
        }

        public int id { get; set; }
        public string Title { get; set; }
        public string Tip { get; set; }
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
