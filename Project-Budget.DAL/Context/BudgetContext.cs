using Microsoft.EntityFrameworkCore;
using Project_Budget.Model.Models;
using Project_Budget.Model.Models.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Budget.DAL.Context
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
