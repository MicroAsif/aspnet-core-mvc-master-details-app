using aspnetcoremaster.core.Interface;
using aspnetcoremaster.core.Model;
using aspnetcoremaster.data.AppDbContext;
using aspnetcoremaster.data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.data.Repository
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(AppDataContext context) : base(context)
        {

        }
    }
}
