using aspnetcoremaster.core.Interface;
using aspnetcoremaster.core.Model;
using aspnetcoremaster.data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.data.Repository
{
    public class CustomerRepository : BaseRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(AppDataContext context) : base(context)
        {

        }
    }
}
