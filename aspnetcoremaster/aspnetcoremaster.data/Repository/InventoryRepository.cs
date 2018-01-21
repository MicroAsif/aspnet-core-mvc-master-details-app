using aspnetcoremaster.core.Interface;
using aspnetcoremaster.core.Model;
using aspnetcoremaster.data.AppDbContext;
using aspnetcoremaster.data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.data.Repository
{
    public class InventoryRepository : BaseRepository<InventoryModel>, IInventoryRepository
    {
        public InventoryRepository(AppDataContext context) : base(context)
        {

        }

    }
}
