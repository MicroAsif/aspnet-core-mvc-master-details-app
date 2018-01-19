using aspnetcoremaster.core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aspnetcoremaster.core.Model
{
    [Table("Category")]
    public class CategoryModel : BaseModel
    {
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }

        public CategoryModel()
        {
            Products = new List<ProductModel>();
        }

        
    }
}
