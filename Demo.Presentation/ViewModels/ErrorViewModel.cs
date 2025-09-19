using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessDAL_Infrastructure_.Models
{
    public class ErrorViewModel
    {

        public string RequestId { get; set; }=string.Empty;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Message { get; set; }=string.Empty;

        public string Details { get; set; }=string.Empty ;

        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
