using aspnetcoremaster.core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Total Price")]
        public float TotalPrice { get; set; }
        [DisplayName("Price")]
        public float Price { get; set; }


        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }

        [ForeignKey("InventoryModel")]
        public int InventoryId { get; set; }
        public InventoryModel InventoryModel { get; set; }
    }
}
