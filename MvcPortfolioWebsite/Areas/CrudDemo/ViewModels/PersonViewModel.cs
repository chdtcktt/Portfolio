using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPortfolioWebsite.Areas.CrudDemo.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}