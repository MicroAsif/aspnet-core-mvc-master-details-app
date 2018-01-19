using aspnetcoremaster.core.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aspnetcoremaster.core.Model
{
    [Table("Products")]
    public class ProductModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }


        [ForeignKey("CategoryModel")]
        [DisplayName("Category")]
        [Required]
        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }


    }
}
