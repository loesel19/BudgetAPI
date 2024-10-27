using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Entry : BaseEntity
    {
        [ForeignKey("CategoryId")]
        public int CategoryId {  get; set; }
        public string? Description { get; set; } = string.Empty;
        public double? Amount { get; set; }
        public DateTime Date {  get; set; }
    }
}
