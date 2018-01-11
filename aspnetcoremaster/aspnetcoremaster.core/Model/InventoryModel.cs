using aspnetcoremaster.core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aspnetcoremaster.core.Model
{
    public class InventoryModel : BaseModel
    {
        public string Code { get; set; }
        public float TotalAmount { get; set; }
        public string Status { get; set; }
        public float GivenAmount { get; set; }
        public float ChangeAmount { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }
    }
}
