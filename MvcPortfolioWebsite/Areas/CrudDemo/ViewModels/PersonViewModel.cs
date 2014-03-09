using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO;

namespace MvcPortfolioWebsite.Areas.CrudDemo.ViewModels
{
    public class PersonViewModel
    {
        public List<Person> Persons { get; set; }
    }
}