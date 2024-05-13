using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLNDotNetCore.NLayer.ConnectionStrings;

namespace SLNDotNetCore.NLayer.Models
{
    internal class AppDbContex : DbContext
    {
        //ConnectoinStrings connectoinStrings = new ConnectoinStrings();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectoinStrings._constringbuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
