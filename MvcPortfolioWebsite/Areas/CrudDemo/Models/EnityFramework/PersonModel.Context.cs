﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcPortfolioWebsite.Areas.CrudDemo.Models.EnityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_9ACB28_CrudDemoEntities : DbContext
    {
        public DB_9ACB28_CrudDemoEntities()
            : base("name=DB_9ACB28_CrudDemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Custom_Person> Custom_Person { get; set; }
    }
}
