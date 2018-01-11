using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aspnetcoremaster.core.Model
{
    public class InventoryItem
    {
        public int Quantity { get; set; }
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
