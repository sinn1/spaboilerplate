using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SPABoilerplate.DAL.EF;
using SPABoilerplate.Models;

namespace SPABoilerplate.Database.EntityFrameworks
{
    public class EfContext : DbContext, IEfContext
    {
        public EfContext() : base("name=DefaultConnection")
        {
        }

        //override OnModelCreating and use fluent API to prevent cascade deletes
        /*  modelBuilder.Entity<Value>()
            .HasRequired<Data>(value => value.Data)
            .WithMany(data => data.Values)
            .HasForeignKey(value => value.DataId)
            .WillCascadeOnDelete(false); */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Data> Data { get; set; }
    }
}