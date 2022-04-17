using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.Entities
{
    public class Personal : BaseEntity
    {
      
        public string NameANdSurname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdentifierNumber { get; set; }
        public string Address { get; set; }
        public string Twitter { get; set; }
        public string FaceBook { get; set; }
        public string Linkedlin { get; set; }

        public int? DepartMentId { get; set; }
        public Department Department { get; set; }
    }
}
