using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public interface IEntity
    {
        int? Id { get; set; }
        int UpdatedBy { get; set; }
        int AddedBy { get; set; }
        DateTime? DateAdded { get; set; }
        DateTime? DateUpdated { get; set; }
        bool IsDeleted { get; set; }
    }
}
