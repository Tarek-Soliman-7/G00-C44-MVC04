using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicBLL.DTOS
{
    public class CreateDepartmentDto
    {
        //[Required(ErrorMessage = "Name Is Requiered !")]
        public string Name { get; set; } = string.Empty;   
        //[Required(ErrorMessage ="Code Is Requiered !")]
        public string Code {  get; set; }=string.Empty;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
