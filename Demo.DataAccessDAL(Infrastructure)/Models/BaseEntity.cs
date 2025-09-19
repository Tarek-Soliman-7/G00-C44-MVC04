using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Models
{
    [NotMapped]
    public   class BaseEntity
    {
        
        public int CreatedBy {  get; set; }
        public DateTime? CreatedOn {  get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
