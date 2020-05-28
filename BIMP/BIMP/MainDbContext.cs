using BIMP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BIMP
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base("name=MySQLConnStr")
        {

        }
        public DbSet<users> users { get; set; }
        public DbSet<Lists> Lists { get; set; }
        public DbSet<schedules> Schedules { get; set; }
        public DbSet<Companys> Companys { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Sales> Sales { get; set; }

    }
}