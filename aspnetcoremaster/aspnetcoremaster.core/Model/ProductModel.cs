using aspnetcoremaster.core.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.core.Model
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }


    }
}
