using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? RecordUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
