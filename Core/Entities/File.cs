using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class File: BaseEntity
    {
        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}