using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Name should be atleast 3 character long")]
        public string Name { get; set; }
    }
}
