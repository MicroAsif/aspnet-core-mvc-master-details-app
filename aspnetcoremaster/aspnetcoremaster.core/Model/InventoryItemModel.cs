using aspnetcoremaster.core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aspnetcoremaster.core.Model
{
    [Table("InventoryItem")]
    public class InventoryItemModel : BaseModel
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        public string ProductName { get; set; }


        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }

        [ForeignKey("InventoryId")]
        public int InventoryId { get; set; }
        public InventoryModel InventoryModel { get; set; }
    }
}
