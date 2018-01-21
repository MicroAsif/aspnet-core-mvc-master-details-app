using aspnetcoremaster.core.Interface.BaseRepository;
using aspnetcoremaster.core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcoremaster.core.Interface
{
    public interface ICustomerRepository : IRepository<CustomerModel>
    {
        IEnumerable<SelectListItem> CustomerForDropdown();
    }
}
