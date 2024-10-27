using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Dtos
{
    public class EntryDto : BaseDto
    {
        public int CategoryId { get; set; }
        public string? Description { get; set; } = string.Empty;
        public double? Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
