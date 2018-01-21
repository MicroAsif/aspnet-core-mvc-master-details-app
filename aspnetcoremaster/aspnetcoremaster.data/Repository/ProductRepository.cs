using aspnetcoremaster.core.Interface;
using aspnetcoremaster.core.Model;
using aspnetcoremaster.data.AppDbContext;
using aspnetcoremaster.data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspnetcoremaster.data.Repository
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(AppDataContext context) : base(context)
        {

        }
        public IEnumerable<SelectListItem> ProductForDropdownByCategory(int categoryId = 0)
        {
            if (categoryId == 0)
            {
                return All().ToList().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            }
            return All().ToList().Where(x => x.CategoryId == categoryId).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
}
