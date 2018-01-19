using aspnetcoremaster.core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace aspnetcoremaster.core.Model
{
    public class CustomerModel :  BaseModel 
    {
        [Required]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
