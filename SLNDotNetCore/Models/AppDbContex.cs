using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLNDotNetCore.ConsoleApp.ConnectionStrings;

namespace SLNDotNetCore.ConsoleApp.Models
{
    internal class AppDbContex : DbContext
    {
        ConnectoinStrings connectoinStrings = new ConnectoinStrings();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectoinStrings._constringbuilder.ConnectionString);
        }
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
