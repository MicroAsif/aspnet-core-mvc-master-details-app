using aspnetcoremaster.core.Interface;
using aspnetcoremaster.core.Model;
using aspnetcoremaster.data.AppDbContext;
using aspnetcoremaster.data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.data.Repository
{
    public class InventoryItemRepository : BaseRepository<InventoryItemModel>, IInventoryItemRepository
    {
        public InventoryItemRepository(AppDataContext context) : base(context)
        {

        }
    }
}
