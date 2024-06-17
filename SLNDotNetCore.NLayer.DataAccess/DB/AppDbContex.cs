using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLNDotNetCore.NLayer.DataAccess.ConnectionStrings;
using SLNDotNetCore.NLayer.DataAccess.Models;

namespace SLNDotNetCore.NLayer.DataAccess.DB
{
    internal class AppDbContex : DbContext
    {
        //ConnectionStrings connectionStrings = new ConnectionStrings();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.ConnectionStrings._constringbuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
